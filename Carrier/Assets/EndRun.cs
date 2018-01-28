using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRun : MonoBehaviour {

	IEnumerator WaitLoadScene (string sceneName) {
		yield return new WaitForSeconds (1);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}

	public void OnTriggerEnter(Collider other) {
		ScreenFader.Instance.FadeOut ();
		GameStats.Instance.RunCount += 1;

		StartCoroutine (WaitLoadScene ("results"));
	}
}
