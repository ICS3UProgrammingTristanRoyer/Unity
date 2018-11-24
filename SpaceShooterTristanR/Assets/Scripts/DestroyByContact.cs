using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	// declare variables
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	// obtains the gameController access while inside asteroid's script
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot Find 'GameController' script");
		}

	
	}
	// creates a function 
	void OnTriggerEnter(Collider other)
	{
		// if the asteroid collides with the boundary limit it will be deleted.
	   if (other.tag == "Boundary")
		{
			return;
		}
	   Instantiate(explosion, transform.position, transform.rotation);
		// if the game sees that the asteroid collieded with the player it will cause the user to lose the game
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore(scoreValue);
	   Destroy(other.gameObject);
	   Destroy(gameObject);
	}
}
