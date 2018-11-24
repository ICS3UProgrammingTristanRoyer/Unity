using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{// declare variables.
	public float speed;

	private Rigidbody rb;

	// assigns values to the variables and sets the speed at which the asteroid falls.
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}
	

	
}
