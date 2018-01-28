using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEndRunStatus : MonoBehaviour {

	public UnityEngine.UI.Text runTitle;
	public UnityEngine.UI.Text[] birdStatusDisplay;
	public AudioClip[] birdSounds;
	public AudioSource source;

	public float timePerStatus;
	private int statusCount;
	private float timeAcc;


	void Awake() {
		for(int i = 0; i < birdStatusDisplay.Length; i++) {
			birdStatusDisplay [i].gameObject.SetActive (false);
		}
	}

	void Start () {
		if (GameStats.Instance.RunCount >= 7) {
			if (GameStats.Instance.FriendCount () == GameStats.BirdsToSeduce) {
				runTitle.text = "You lived and you made lots of living friends!";
			} else {
				runTitle.text = "You lived, congratulations!";
			}
		} else {
			runTitle.text = "End of run " + GameStats.Instance.RunCount.ToString ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeAcc += Time.deltaTime;
		if (timeAcc >= timePerStatus && statusCount < GameStats.BirdsToSeduce) {
			timeAcc = 0;
			birdStatusDisplay [statusCount].gameObject.SetActive (true);
			BirdState bs = GameStats.Instance.Birds [statusCount];

			string state = "Wild";
			if (bs.alive && bs.seduced) {
				state = "Friendly";
			}

			if (!bs.alive) {
				state = "Dead";
			}
			source.PlayOneShot(birdSounds[statusCount]);
			birdStatusDisplay [statusCount].text = ((BirdType)(statusCount+1)).ToString () + ": " + state;
			statusCount += 1;
		}
	}
}
