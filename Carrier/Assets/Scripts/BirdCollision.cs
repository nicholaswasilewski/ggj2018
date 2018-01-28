using UnityEngine;
using System.Collections;

public class BirdCollision : MonoBehaviour 
{
	public SaucyBird bird;

	void OnTriggerEnter (Collider other)
	{
//		ModalLogic.birdSelect (bird.BirdNumber);
		Debug.Log ("Enter: " + this.gameObject.name + " with " + other.gameObject.name);
		bird.StartDialogue ();
	}
}
