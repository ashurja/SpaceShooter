// Jamshed Ashurov
// 03/01/2018
// This script rotates the object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	private Rigidbody rb;
	public float Tumble;

	void Start()
	{
		rb = GetComponent <Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * Tumble; // Rotates the object with the specified spin  
	}
		
}
