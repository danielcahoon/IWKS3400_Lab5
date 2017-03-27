using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomishSquishManagement : MonoBehaviour {
	public GameObject shroomish;
	public GameObject colliderBox;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			Destroy (shroomish);
			Destroy (colliderBox);
		}
	}

	void FixedUpdate()
	{
		transform.position = new Vector3 (shroomish.transform.position.x, shroomish.transform.position.y, shroomish.transform.position.z);
	}
}
