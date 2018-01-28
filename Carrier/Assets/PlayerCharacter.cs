using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	int playerLayer;
	int terrainLayer;
	int bulletLayer;
	int npcLayer;

	// Use this for initialization
	void Start () {
		npcLayer = LayerMask.NameToLayer ("npc birds");
		playerLayer = LayerMask.NameToLayer ("player");
		terrainLayer = LayerMask.NameToLayer ("terrain");
		bulletLayer = LayerMask.NameToLayer("bullet");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == terrainLayer) {
			Debug.Log ("game over");
			ScreenFader.Instance.SetColor (Color.red);
			ScreenFader.Instance.fadeTime = 0;
			ScreenFader.Instance.FadeOut ();
		}
	}
}
