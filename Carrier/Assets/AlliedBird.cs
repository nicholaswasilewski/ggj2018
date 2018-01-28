using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedBird : MonoBehaviour {

	public BirdType birdType;

	void OnTriggerEnter(Collider other) {
		GameStats.Instance.KillBird (birdType);
		transform.parent = null;
		gameObject.GetComponent<Rigidbody> ().useGravity = true;
	}
}
