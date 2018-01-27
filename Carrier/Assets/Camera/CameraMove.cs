using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	// Use this for initialization

	public float moveSpeed;
	new Transform transform;

	void Start () {
		transform = gameObject.transform;
	}

	void Move(Vector3 move) {
		transform.Translate (move.normalized * moveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		Vector3 moveVector = Vector3.zero;
		if (vertical > 1.0f) {
			moveVector += transform.forward;
		} else if (vertical < 0.0f) {
			moveVector -= transform.forward;
		}

		if (horizontal > 0.0f) {
			moveVector += transform.right;
		} else if (horizontal < 0.0f) {
			moveVector -= transform.right;
		}
		Debug.Log (vertical.ToString() + ", " + horizontal.ToString());
		Move (moveVector);
	}
}
