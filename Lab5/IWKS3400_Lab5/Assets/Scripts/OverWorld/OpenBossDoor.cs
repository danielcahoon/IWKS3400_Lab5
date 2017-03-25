using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBossDoor : MonoBehaviour {


	private Animator anim;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		anim.SetBool("BossDoorOpen", true);
	}
}
