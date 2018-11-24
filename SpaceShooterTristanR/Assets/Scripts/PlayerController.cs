using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Boundary
{

	// creates the barriers for the boundary.
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	// declare variables
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private AudioSource audioSource;
	private Rigidbody rb;

	// Creates a function that allows the player to shoot laser projectiles that make a sound
	void Update ()
	{
		if (Input.GetButton("Jump") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play();

		}

	}

	// assigns values to  variables
void Start()
{
	rb = GetComponent<Rigidbody>();
	audioSource = GetComponent<AudioSource>();

	
}


	

void FixedUpdate ()
	{

	float moveHorizontal = Input.GetAxis("Horizontal");
	float moveVertical = Input.GetAxis("Vertical");
	Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    rb.velocity = movement * speed;
		rb.position = new Vector3
		(
		Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
		0.0f,
		Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)


		);
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
	
	
}
