using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmo : MonoBehaviour {

	float speed = 50.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.forward*speed*Time.deltaTime);
	}
}
