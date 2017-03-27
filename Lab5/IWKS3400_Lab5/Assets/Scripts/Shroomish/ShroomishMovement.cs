using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomishMovement : MonoBehaviour {

	public float velocity = 50f;
	public float maxSpeed = 3;
	private float direction;
	public static bool squished;
	public GameObject shroomish;
	Rigidbody2D rb2d;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		direction = 1;
	}

	void OnTriggerEnter2D(Collider2D collide)
	{
		if (direction > 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		else 
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}
			
		direction *= -1;
	}


	// Update is called once per frame
	void Update () {
		anim.SetBool ("Squished", squished);
		anim.SetFloat ("Velocity", velocity);
	}
	void FixedUpdate()
	{
		if (direction > 0) {
			rb2d.AddForce (Vector2.right * velocity);
		} else {
			rb2d.AddForce (Vector2.left * velocity);
		}

		//Character Speed regulation
		if(rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if(rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
	void DestroyItself()
	{
		Destroy (shroomish);
	}
}
