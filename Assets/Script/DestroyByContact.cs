// Jamshed Ashurov
// 03/01/2018
// This script destroys the object through contact and adds the point once the ship destroys the asteroids.  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerexplosion;
	public int scoreValue;
	private GameController gc;


	void Start(){
		GameObject gcObject = GameObject.FindWithTag ("GameController");
		if (gcObject != null) { // Gets the information from the GameController Script 
			gc = gcObject.GetComponent <GameController> ();
		}

		if (gc == null) { // In case it cannot access the info from the GameController script, it will show the text below.
			Debug.Log ("Cannot find 'GameController' script"); 
		}
	}
	void OnTriggerEnter(Collider other) {  
		if (other.tag == "Boundary") { // If the tag is "Boundary", it would not destroy 
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") { // If the tag is "Player", it makes the explosion and uses the "Gameover" function from the GameController Script
			Instantiate (playerexplosion, other.transform.position, other.transform.rotation);
			gc.Gameover ();
		}
		gc.Addscore (scoreValue); // Once the ship destroys the objects, it updates the score. 
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
