using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {
	private Transform transform;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardSpeed = 0.05f;
		float sideSpeed = 5f;
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
		transform.Translate (new Vector3 (left, up, forwardSpeed));
	}
}
