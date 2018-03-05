// Jamshed Ashurov
// 03/01/2018
// This script destroys the object through time 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public float lifetime;// Destroys the object ones the lifetime is over 
	void Start () 
	{
		
		Destroy (gameObject, lifetime);
	}
}
