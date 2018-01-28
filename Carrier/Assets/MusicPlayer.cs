using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	public AudioSource audioSource;

	public static MusicPlayer Instance;

	void Awake() {
		Instance = this;
	}
}
