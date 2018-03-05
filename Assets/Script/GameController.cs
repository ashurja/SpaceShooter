// Jamshed Ashurov
// 03/01/2018
// This script creates a game controller, which is used to restart the game, update the score, add the waittime, and spawn enemies.  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public float Wavewait;
	public float spawnwait;
	public float startwait;
	public int Hazardcount;
	public GameObject[] hazards;
	public Vector3 spawnValues;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private int score;
	private bool gameOver;
	private bool restart; 

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (Spawnwaves ());
	}

	void Update()
	{ // These lines of code sets the key "R" as the game reloader 
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	IEnumerator Spawnwaves ()
	// We use the IEnumerator to suspense the action. In our case we use it to hold the asteroid to fall instantly at the same time. 
	{
		
		while(true)
		{
			yield return new WaitForSeconds (startwait); // This one is used in the beginning of the game to give user some time to prepare 
			for (int i = 0;i < Hazardcount; i++) 
				{
					GameObject hazard = hazards [Random.Range (0, hazards.Length)];
					Vector3 spawnposition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnrotation = Quaternion.identity;
					Instantiate (hazard, spawnposition , spawnrotation); 
					yield return new WaitForSeconds (spawnwait); // This one is used so that asteroid would fall consequently, not at the same time. 
				}
			yield return new WaitForSeconds (Wavewait); // This one is used to give breaks between the waves

			if (gameOver) { // Shows the Restart Text 
				restartText.text = "Press 'R' for Restart";
				restart = true; 
				break; 
			}
		}
	}

	public void Addscore (int newScoreValue) // Creates the public value called Addscore so that we could access it in other scripts too. 
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void Gameover() // Creates the public value called Gameover so that we could access it in other scripts too. 
	{
		gameOverText.text = "Game Over!"; 
		gameOver = true;
	}
}
