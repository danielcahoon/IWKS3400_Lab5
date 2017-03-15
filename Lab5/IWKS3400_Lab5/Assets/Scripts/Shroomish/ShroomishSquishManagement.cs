using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomishSquishManagement : MonoBehaviour {
	public GameObject shroomish;
	//private Animator anim;
	// Use this for initialization
	void Start () {
	//	anim = gameObject.GetComponentInParent<Animator>();
//		shroomish = gameObject.GetComponent("Shroomish");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		ShroomishMovement.squished = true;
	}
	void DestroyItself()
	{
		Destroy (shroomish);
	}
}
