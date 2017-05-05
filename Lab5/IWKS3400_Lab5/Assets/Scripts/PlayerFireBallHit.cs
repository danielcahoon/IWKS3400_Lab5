using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBallHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Enemy")) {
			col.GetComponent<ShroomishMovement> ().DestroyItself ();
			Destroy (gameObject);

		} else if (col.CompareTag ("Boss")) {
			//Hurt boss

			Destroy (gameObject);
		} else if (col.CompareTag ("Map")) {
			Destroy (gameObject);
		}
	}
}
