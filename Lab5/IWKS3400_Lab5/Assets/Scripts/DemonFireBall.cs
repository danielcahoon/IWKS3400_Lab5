using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFireBall : MonoBehaviour {
	//Integers
	public int currentHealth;
	public int maxHealth;

	//Floats
	public float distance;
	public float wakeRange; //used to know if the character is close enough
	public float shootInterval;
	public float fireBallSpeed = 100;
	public float fireBallTimer;

	//Bool
	bool active;

	//References
	public GameObject fireBall;
	public Transform target;
	public Animator anim;
	public Transform shootPoint;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();
	}

	void Start()
	{
		currentHealth = maxHealth;
	}

	void Update()
	{
		RangeCheck ();
	}

	void RangeCheck()
	{
		distance = Vector3.Distance (transform.position, target.transform.position);
		if (distance < wakeRange) {
			active = true;
		}

		if (distance > wakeRange) {
			active = false;
		}
	}

	public void Attack(bool attack)
	{
		fireBallTimer += Time.deltaTime;

		if (fireBallTimer >= shootInterval) {

			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			GameObject fireBallClone;
			fireBallClone = Instantiate (fireBall, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			fireBallClone.GetComponent<Rigidbody2D> ().velocity = direction * fireBallSpeed;


			fireBallTimer = 0;
				
		}

	}


}
