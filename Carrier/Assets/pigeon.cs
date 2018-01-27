using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {
	private Transform transform;
	private Transform cameraTransform;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardSpeed = 1f;
		float sideSpeed = 50f;
		float up = 0f;
		float left = 0f;

		if (Input.GetKey(KeyCode.W)) {
			up = sideSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)) {
			left = -sideSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)) {
			up = -sideSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D)) {
			left = sideSpeed * Time.deltaTime;
		}
		Vector3 translation = new Vector3 (left, up, forwardSpeed);
		transform.Translate(translation);
		cameraTransform.Translate(translation);
	}
}
