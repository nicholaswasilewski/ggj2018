using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
	private Transform cameraTransform;
	private Transform tiltTransform;
	private MeshRenderer[] birds = new MeshRenderer[7];

	private float translateSpeed = 100f;
	private float tiltSpeed = 100f;
	private float maxTilt = 20f;

	private const KeyCode LeftKey = KeyCode.A;
	private const KeyCode RightKey = KeyCode.D;
	private const KeyCode UpKey = KeyCode.W;
	private const KeyCode DownKey = KeyCode.S;

	private bool rolling;
	private float rollDirection;
	private float rollTime;

	private float targetRollTime = .4f;
	private float rollDetectionTime = 0.2f;
	private float lastLeftTime = 0.0f;
	private float lastRightTime = 0.0f;

	void Start () {
		cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
		tiltTransform = GameObject.Find("FlockTilt").GetComponent<Transform>();
		birds[0] = GameObject.Find("Bird1").GetComponent<MeshRenderer>();
		birds[1] = GameObject.Find("Bird2").GetComponent<MeshRenderer>();
		birds[2] = GameObject.Find("Bird3").GetComponent<MeshRenderer>();
		birds[3] = GameObject.Find("Bird4").GetComponent<MeshRenderer>();
		birds[4] = GameObject.Find("Bird5").GetComponent<MeshRenderer>();
		birds[5] = GameObject.Find("Bird6").GetComponent<MeshRenderer>();
		birds[6] = GameObject.Find("Bird7").GetComponent<MeshRenderer>();

		birds[6].enabled = false;
		birds[0].enabled = false;
		birds[3].enabled = false;
	}

	void Update () {

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
			Vector3 angles = tiltTransform.localEulerAngles;
			if (rollTime >= targetRollTime) {
				rolling = false;
				rollTime = targetRollTime;
				angles.z = 0.0f;
			} else {
				angles.z = Mathf.Lerp (0.0f, rollDirection, rollTime / targetRollTime);
				Debug.Log ("Roll Time: " + rollTime + ", " +angles.z);
			}
			tiltTransform.localEulerAngles = angles;
		}

		// Collect input
		int left = 0;
		int up = 0;
		if (Input.GetKey(UpKey)) {
			up += 1;
		}
		if (Input.GetKey(LeftKey)) {
			left += 1;
		}
		if (Input.GetKey(DownKey)) {
			up -= 1;
		}
		if (Input.GetKey(RightKey)) {
			left -= 1;
		}

		// Rotate the flock
		Vector3 currentTilt = tiltTransform.localEulerAngles;
		Vector3 targetTilt = new Vector3(currentTilt.x, currentTilt.y, currentTilt.z);
		if (left > 0) {
			targetTilt.z = (targetTilt.z - tiltSpeed * Time.deltaTime + 360) % 360;
			if ((targetTilt.z > 180) && (targetTilt.z < 360 - maxTilt)) {
				targetTilt.z = 360 - maxTilt;
			}
		} else if (left < 0) {
			targetTilt.z = (targetTilt.z + tiltSpeed * Time.deltaTime + 360) % 360;
			if ((targetTilt.z < 180) && (targetTilt.z > maxTilt)) {
				targetTilt.z = maxTilt;
			}
		} else {
			if (currentTilt.z > 0 && currentTilt.z < 180) {
				targetTilt.z = (targetTilt.z - tiltSpeed * Time.deltaTime + 360) % 360;
				if (targetTilt.z > maxTilt)
					targetTilt.z = 0;
			} else if (currentTilt.z > 180) {
				targetTilt.z = (targetTilt.z + tiltSpeed * Time.deltaTime + 360) % 360;
				if (targetTilt.z < 360 - maxTilt)
					targetTilt.z = 0;
			}
		}
		if (up > 0) {
			targetTilt.x = (targetTilt.x + tiltSpeed * Time.deltaTime + 360) % 360;
			if ((targetTilt.x > maxTilt) && (targetTilt.x < 180)) {
				targetTilt.x = maxTilt;
			}
		} else if (up < 0) {
			targetTilt.x = (targetTilt.x - tiltSpeed * Time.deltaTime + 360) % 360;
			if ((targetTilt.x < 360 - maxTilt) && (targetTilt.x > 180)) {
				targetTilt.x = 360 - maxTilt;
			}
		} else {
			if (currentTilt.x > 0 && currentTilt.x < 180) {
				targetTilt.x = (targetTilt.x - tiltSpeed * Time.deltaTime + 360) % 360;
				if (targetTilt.x > maxTilt)
					targetTilt.x = 0;
			} else if (currentTilt.x > 180) {
				targetTilt.x = (targetTilt.x + tiltSpeed * Time.deltaTime + 360) % 360;
				if (targetTilt.x < 360 - maxTilt)
					targetTilt.x = 0;
			}
		}
		if (!rolling)
			tiltTransform.localEulerAngles = new Vector3 (targetTilt.x, 0, targetTilt.z);

		// Move flock and reset camera
		transform.Translate(new Vector3(left * translateSpeed * Time.deltaTime, up * translateSpeed * Time.deltaTime, -100f * Time.deltaTime));
		cameraTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 25);
	}
}
