using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRun : MonoBehaviour {
	public void OnTriggerEnter(Collider other) {
		ScreenFader.Instance.FadeOut ();
	}
}
