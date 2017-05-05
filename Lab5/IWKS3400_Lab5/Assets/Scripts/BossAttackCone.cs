using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackCone : MonoBehaviour {

	public DemonFireBall demonFireBall;


	void Awake()
	{
		demonFireBall = gameObject.GetComponentInParent<DemonFireBall> ();
	}

	void OnTriggerEnter2d(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			demonFireBall.Attack ();
		}
	}
}
