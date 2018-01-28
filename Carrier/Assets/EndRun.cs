using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRun : MonoBehaviour {
	public void OnTriggerEnter(Collider other) {
		ScreenFader.Instance.FadeOut ();
		GameStats.Instance.RunCount += 1;

		if (GameStats.Instance.RunCount >= 7) {
			//Final score screen
		}
	}
}
