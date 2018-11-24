using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ // declare variables
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	private int score;
	public Text restartText;
	public Text gameOverText;
	private bool gameOver;
	private bool restart;
	private AudioSource audioS;
	
	
	// creates a start function  which changes the values of objects , starts the wave spawn and Updates the score
	void Start()
	{
		audioS = GetComponent<AudioSource>();
		gameOver = false; 
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0; 
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	// function which restarts the game if the game is over and the R key is pressed
	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}


	    // creates a mute and un-mute feature for the background music 
		//Source:https://forum.unity.com/threads/mute-and-unmute.504438/
		
			if (Input.GetButton("Cancel") && audioS.isPlaying)
			{

				audioS.Pause();

			}

			else if (Input.GetButton("Cancel"))
			{
				

				audioS.Play();

			}
		
	}
	// Function used to spawn endless amounts of waves
	IEnumerator SpawnWaves()
	{
		// allows the wave spawn to pause inbetween each set.
		yield return new WaitForSeconds(startWait);

		// while true it will endlessly spawn waves of asteroids against the player
		while (true)
		{ for (int counter = 0; counter < hazardCount; counter++)
			{
				GameObject hazard = hazards [Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			// if the game is over display the message to instruct the player on how to restart the game and sets restart to be true.
			if (gameOver)
			{
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}

	}
	// function to increase the score.
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}
	// function to update the score text to display the appropriate score value
	void UpdateScore()
	{
		scoreText.text = "Score:" + score;

	}

	// function the updates the game over text to display "game over" and sets game over to be true.
	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
