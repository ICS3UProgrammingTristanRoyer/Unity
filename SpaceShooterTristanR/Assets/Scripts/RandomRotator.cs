using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	// declare variables
	public float tumble;
	private Rigidbody rb;

	void Start ()
	{
		// assign values to the variables , uses a function to allow the asteroid to "tumble" to make it look realistic.
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
}
