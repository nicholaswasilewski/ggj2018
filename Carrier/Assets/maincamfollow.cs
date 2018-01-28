using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamfollow : MonoBehaviour {

	public GameObject box;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = box.transform.position - box.transform.forward * 5;
	}
}
