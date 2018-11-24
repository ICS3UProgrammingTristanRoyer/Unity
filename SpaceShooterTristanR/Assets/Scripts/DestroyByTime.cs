using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
	// declare variable
	public float lifetime;
	// Creates a function that destroys a game object after the lifetime limit is up.
	void Start ()
	{
		Destroy(gameObject , lifetime);



	}
}
