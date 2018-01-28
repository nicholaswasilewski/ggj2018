using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEndRunStatus : MonoBehaviour {

	public UnityEngine.UI.Text runTitle;
	public UnityEngine.UI.Text[] birdStatusDisplay;

	public float timePerStatus;
	private int statusCount;
	private float timeAcc;


	void Awake() {
		for(int i = 0; i < birdStatusDisplay.Length; i++) {
			birdStatusDisplay [i].gameObject.SetActive (false);
		}
	}

	void Start () {
		runTitle.text = "End of run " + GameStats.Instance.RunCount.ToString ();
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
				state = "Alive";
			}

			if (!bs.alive) {
				state = "Dead";
			}
			birdStatusDisplay [statusCount].text = ((BirdType)(statusCount+1)).ToString () + ": " + state;
			statusCount += 1;
		}
	}
}
