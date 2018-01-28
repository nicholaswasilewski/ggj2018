using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {
	private Transform cameraTransform;
	private Transform rotateTransform;

	private const KeyCode LeftKey = KeyCode.A;
	private const KeyCode RightKey = KeyCode.D;

	private bool rolling;
	private float rollDirection;
	private float rollTime;

	private float targetRollTime = .4f;
	private float rollDetectionTime = 0.2f;
	private float lastLeftTime = 0.0f;
	private float lastRightTime = 0.0f;

	// Use this for initialization
	void Start () {
		cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
		rotateTransform = GameObject.Find("Pigeon").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardSpeed = 1f;
		float sideSpeed = 50f;
		float up = 0f;
		float left = 0f;

		int htilt = 0;
		int vtilt = 0;

		if (!rolling) {
			if (Input.GetKeyDown (LeftKey)) {
				if (Time.time - lastLeftTime <= rollDetectionTime) {
					rolling = true;
					rollTime = 0.0f;
					rollDirection = -360.0f;
				} else {
					lastLeftTime = Time.time;
				}
			}

			if (Input.GetKeyDown (RightKey)) {
				if (Time.time - lastRightTime <= rollDetectionTime) {
					rolling = true;
					rollTime = 0.0f;
					rollDirection = 360.0f;
				} else {
					lastRightTime = Time.time; 
				}
			}
		} else {
//			Debug.Log ("Rolling, Roll Direction: " + rollDirection + ",  RollTime: " + rollTime);
			rollTime += Time.deltaTime;
			Vector3 angles = rotateTransform.localEulerAngles;
			if (rollTime >= targetRollTime) {
				rolling = false;
				rollTime = targetRollTime;
				angles.z = 0.0f;
			} else {
				angles.z = Mathf.Lerp (0.0f, rollDirection, rollTime / targetRollTime);
				Debug.Log ("Roll Time: " + rollTime + ", " +angles.z);
			}
			rotateTransform.localEulerAngles = angles;
		}
			


		if (Input.GetKey(KeyCode.W)) {
			up = sideSpeed * Time.deltaTime;
			vtilt += 1;
		}
		if (Input.GetKey(LeftKey)) {
			left = -sideSpeed * Time.deltaTime;
			htilt -= 1;
		}
		if (Input.GetKey(KeyCode.S)) {
			up = -sideSpeed * Time.deltaTime;
			vtilt -= 1;
		}
		if (Input.GetKey(RightKey)) {
			left = sideSpeed * Time.deltaTime;
			htilt += 1;
		}

		float tiltSpeed = 300f;
		float maxTilt = 30f;
		float currentHTilt = rotateTransform.localEulerAngles.z;
		float currentVTilt = rotateTransform.localEulerAngles.x;

		// Tilt because a button is pressed
		if (htilt != 0) {
			float tiltDiff = htilt * tiltSpeed * Time.deltaTime;
			float newTilt = currentHTilt + tiltDiff;
			if (htilt > 0 && ((newTilt > 360 - maxTilt) || (newTilt < maxTilt))) {
				rotateTransform.Rotate (new Vector3 (0, 0, tiltDiff));
			} else if (htilt < 0 && ((newTilt > 360 - maxTilt) || (newTilt < maxTilt))) {
				rotateTransform.Rotate (new Vector3 (0, 0, tiltDiff));
			}
		}
		// Tilt back to vertical
		else {
			if (currentHTilt > 0 && currentHTilt <= maxTilt) {
				float tiltDiff = Mathf.Min (currentHTilt, tiltSpeed * Time.deltaTime);
				rotateTransform.Rotate (new Vector3 (0, 0, -tiltDiff));
			} else if (currentHTilt >= 360 - maxTilt) {
				float tiltDiff = Mathf.Min (360 - currentHTilt, tiltSpeed * Time.deltaTime);
				rotateTransform.Rotate (new Vector3 (0, 0, tiltDiff));
			}
		}

		// Tilt because a button is pressed
		if (vtilt != 0) {
			float tiltDiff = vtilt * tiltSpeed * Time.deltaTime;
			float newTilt = currentVTilt + tiltDiff;
			if (vtilt > 0 && ((newTilt > 360 - maxTilt) || (newTilt < maxTilt))) {
				rotateTransform.Rotate (new Vector3 (tiltDiff, 0, 0));
			} else if (vtilt < 0 && ((newTilt > 360 - maxTilt) || (newTilt < maxTilt))) {
				rotateTransform.Rotate (new Vector3 (tiltDiff, 0, 0));
			}
		}
		// Tilt back to vertical
		else {
			if (currentVTilt > 0 && currentVTilt <= maxTilt) {
				float tiltDiff = Mathf.Min (currentVTilt, tiltSpeed * Time.deltaTime);
				rotateTransform.Rotate (new Vector3 (-tiltDiff, 0, 0));
			} else if (currentVTilt >= 360 - maxTilt) {
				float tiltDiff = Mathf.Min (360 - currentVTilt, tiltSpeed * Time.deltaTime);
				rotateTransform.Rotate (new Vector3 (tiltDiff, 0, 0));
			}
		}


		// Translate
		Vector3 translation = new Vector3(left, up, forwardSpeed);
		transform.Translate(translation);
		cameraTransform.Translate(translation);
	}
}
