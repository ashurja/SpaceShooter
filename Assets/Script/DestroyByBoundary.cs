// Jamshed Ashurov
// 03/01/2018
// This script destroys the object once it goes out of the boundary.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		// Destroys everything that leaves the trigger
		Destroy(other.gameObject);
	}

}
