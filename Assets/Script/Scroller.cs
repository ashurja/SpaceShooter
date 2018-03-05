// Jamshed Ashurov
// 03/01/2018
// This script scrolls the background by multiplying the time and the size of the tile 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {
	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition; 
	// Use this for initialization
	void Start () {
		startPosition = transform.position; 
	}
	
	// Update is called once per frame
	void Update () { // The background scroller is in the loop. Once it reaches the end of the background it starts from the initial position. 
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
