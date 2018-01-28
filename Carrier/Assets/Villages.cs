using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villages : MonoBehaviour {
	private List<Transform> houses = new List<Transform>();
	private float lastFire;
	private float firePeriod = 0.3f;
	public Transform bullet;

	void Start() {
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType<GameObject>())
			if (obj.name.StartsWith ("Village "))
				foreach (Transform transform in obj.GetComponentsInChildren(typeof(Transform)))
					houses.Add(transform);
		lastFire = Time.time;
	}
	
	void Update () {
		if (Time.time > lastFire + firePeriod) {
			lastFire = Time.time;
			Fire();
		}
	}

	void Fire() {
		int index = Mathf.FloorToInt(Random.value * (houses.Count - 1));
		Vector3 position = houses [index].position;
//		Debug.Log("[" + index + "] of " + houses.Count + " (" + position.x + ", " + position.y + ", " + position.z + ")");
		Instantiate(bullet, position, Quaternion.identity);



//		Vector3 position = houses [Mathf.FloorToInt (Random.value * (houses.Count - 1))].position;
//		Instantiate(bullet, transform.position, Quaternion.identity);
	}
}
