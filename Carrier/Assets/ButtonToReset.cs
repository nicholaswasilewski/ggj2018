using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToReset : MonoBehaviour {

	public KeyCode resetKey;
	void Update () {
		if (Input.GetKeyDown (resetKey)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("title");
		}
	}
}
