// Jamshed Ashurov
// 03/01/2018
// This script moves the object.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	void Start ()
	{
		rb	= GetComponent < Rigidbody> (); // Moves the object forward times the specific speed
		rb.velocity = transform.forward * speed; 
	}
	
}

