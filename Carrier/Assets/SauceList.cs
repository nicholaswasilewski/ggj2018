using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceList : MonoBehaviour {

	public List<SaucyBird> birds;

	// Use this for initialization
	void Start () {
		int RunNumber = GameStats.Instance.RunCount;

		for (int i = 0; i < birds.Count; i++) {
			birds [i].gameObject.SetActive (RunNumber == i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
