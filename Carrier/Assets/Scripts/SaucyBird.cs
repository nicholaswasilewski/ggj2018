using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucyBird : MonoBehaviour {

	public int BirdNumber;
	public Texture2D Portrait;
	public AudioClip musicClip;
	public AudioClip squawk;

	void Start () {
	}
	void Update () {
		float forwardSpeed = -10f;
		// Translate
		Vector3 translation = new Vector3(0, 0, forwardSpeed)*Time.deltaTime;
		transform.Translate(translation);
	}

	public void StartDialogue(){

		if (MusicPlayer.Instance != null && musicClip != null) {
			MusicPlayer.Instance.audioSource.clip = musicClip;
			MusicPlayer.Instance.audioSource.Play ();
		}

		if (MusicPlayer.Instance != null && squawk != null) {
			MusicPlayer.Instance.audioSource.PlayOneShot (squawk);
		}

		ModalLogic.Instance.birdSelect (BirdNumber, Portrait);
	}
}
