using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
	private Transform cameraTransform;
	private Transform tiltTransform;
	public GameObject[] birds = new GameObject[7];

	public float forwardSpeed = -100f;
	private float sideSpeed = 100f;
	private float tiltSpeed = 100f;
	private float maxTilt = 20f;

	private float maxHeight = 150f;

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

		InitFlock (GameStats.Instance);
	}

	public void InitFlock(GameStats gameStats) {
		BirdState[] birdStats = gameStats.Birds;
		for (int i = 0; i < birdStats.Length; i++) {
			BirdState birdState = birdStats[i];
			birds[i+1].SetActive(birdState.alive && birdState.seduced);
		}
	}

	void Update () {
		float sideSpeed = this.sideSpeed;
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
			sideSpeed = sideSpeed*2;
			rollTime += Time.deltaTime;
			Vector3 angles = tiltTransform.localEulerAngles;
			if (rollTime >= targetRollTime) {
				rolling = false;
				rollTime = targetRollTime;
				angles.z = 0.0f;
			} else {
				angles.z = Mathf.Lerp (0.0f, rollDirection, rollTime / targetRollTime);
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

		// Move the flock, limiting it to a max height
		Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		newPosition.x += left * sideSpeed * Time.deltaTime;
		newPosition.y += up * sideSpeed * Time.deltaTime;
		newPosition.y = Mathf.Min(newPosition.y, maxHeight);
		newPosition.z += forwardSpeed * Time.deltaTime;
		transform.position = newPosition;

		// Camera follows flock
		cameraTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 25);;
	}
}
