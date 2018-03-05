// Jamshed Ashurov
// 03/01/2018
// This script controls the spaceship(Player) by creating the audio, firebutton, buttons for moving, the boundaries for the ship, speed, and rotation.   

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float tilt;
	public Boundary boundary;
	private Rigidbody rb; 
	private AudioSource aud;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;

	private float nextFire;

	void Start(){
		rb = GetComponent <Rigidbody> ();
		aud = GetComponent <AudioSource> (); // Creates a place for Audio
	}

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) // Creates the firebutton. The button is automatically registred as the left mouse. 
		{
			nextFire = Time.time + fireRate; // The shot will be after the specific time
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			aud.Play ();
		}
	}
	void FixedUpdate()
	{
		// Creates the button for moving left and right. The "W", "A", "S", "D" button are automatically registed as the moving buttons.
		float moveHorizontal = Input.GetAxis ("Horizontal");  
		float moveVertical = Input.GetAxis ("Vertical");

		rb.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed; // Creates the variable for the velocity of the ship 

		// Sets the boundaries for the ship, so that it would not disappear out of view. 
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt); // Creates the rotation variable for the ship 
	}
}