using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {


	public float velocity = 50f;
	public float maxSpeed = 3f;

	private int direction = -1;

	private Animator anim;
	private Rigidbody2D rb2d;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (direction > 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		direction *= -1;
	}

	void FixedUpdate()
	{
		rb2d.AddForce ((Vector2.right * velocity) * direction);

		if(rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if(rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
}
