using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucyBird : MonoBehaviour {

	public int BirdNumber;

	void Start () {
	}
	void Update () {
		float forwardSpeed = -10f;
		// Translate
		Vector3 translation = new Vector3(0, 0, forwardSpeed)*Time.deltaTime;
		transform.Translate(translation);
//		cameraTransform.Translate(translation);
	}

	public void StartDialogue(){
		ModalLogic.Instance.birdSelect (BirdNumber);
	}
}
