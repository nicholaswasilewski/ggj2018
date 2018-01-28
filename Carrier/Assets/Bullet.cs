using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Vector3 start;
	private Vector3 vec;

	void Start () {
		start = transform.position;
		vec = Random.onUnitSphere;
		if (vec.y < 0)
			vec.y = -vec.y;
	}
	
	void Update () {
		transform.position += vec * Time.deltaTime * 20f;
		if ((transform.position - start).magnitude > 300f)
			Destroy(gameObject);
	}
}
