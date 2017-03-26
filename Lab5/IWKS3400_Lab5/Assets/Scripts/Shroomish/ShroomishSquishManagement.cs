﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomishSquishManagement : MonoBehaviour {
	public GameObject shroomish;
	//private Animator anim;
	// Use this for initialization
	void Start () {
//		shroomish = gameObject.GetComponent("Shroomish");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			Destroy (shroomish);
		}
	}
	void DestroyItself()
	{
		Destroy (shroomish);
		ShroomishMovement.squished = false;
	}
}
