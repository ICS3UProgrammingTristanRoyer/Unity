using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
	public float scrollSpeed;
	public float tileSizeZ;
	private Vector3 startPosition;

	// sets the start position variable to be the transform of the background
	void Start ()
	{
		startPosition = transform.position;
		
	}
	
	// repeatedly change the location of the background to display a moving background.
	void Update () {
	float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
		
	}
}
