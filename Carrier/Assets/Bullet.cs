using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Vector3 vec;
	private float bulletSpeed = 200f;

	void Start () {
		GameObject flock = GameObject.Find("Flock");
		Flock flockScript = flock.GetComponent<MonoBehaviour>() as Flock;
		Vector3 flockPosition = flock.GetComponent<Transform>().position;

		float lead = -200f;
		Vector3 offset = new Vector3((Random.value - 0.5f) * 100f, (Random.value - 0.5f) * 75f, lead + (Random.value - 0.5f) * 100f);
		vec = (flockPosition + offset - transform.position).normalized;
	}
	
	void Update () {
		transform.position += vec * Time.deltaTime * bulletSpeed;
		if (transform.position.y > 160f)
			Destroy(gameObject);
	}
}
