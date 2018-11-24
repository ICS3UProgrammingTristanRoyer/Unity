using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
	// if an object exits the boundary it will be destroyed.
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}

}
