using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	//Floats
	public float fireBallSpeed = 20;

	//Referennces
	public GameObject fireBall;
	public Transform target;
	public Animator anim;
	public Transform shootPoint;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update()
	{
		Attack ();
	}

	public void Attack()
	{

		if (Input.GetKeyDown (KeyCode.H)) {
			Vector2 direction = Vector2.right;
			direction.Normalize ();

			GameObject fireBallClone;
			fireBallClone = Instantiate (fireBall, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			fireBallClone.GetComponent<Rigidbody2D> ().velocity = direction * fireBallSpeed;

		}

	}


}
