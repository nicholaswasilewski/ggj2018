using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	// Use this for initialization

	public float moveSpeed;

	void Start () {
	}

	void Move(Vector3 move) {
		float moveMagnitude = move.magnitude;
		if (moveMagnitude > moveSpeed) {
			moveMagnitude = moveSpeed;
		}

		if (move.sqrMagnitude > moveSpeed * moveSpeed) {
			move = move.normalized;
		}
		transform.Translate (move.normalized * moveSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		Vector3 moveVector = Vector3.zero;
		moveVector += transform.forward*vertical;
		moveVector += transform.right*horizontal;
		Move (moveVector);
	}
}
