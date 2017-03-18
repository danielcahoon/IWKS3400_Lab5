using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldPlayer : MonoBehaviour {

	public float maxSpeed = 3f;		//Maximum speed we will allow the player to go
	public float velocity = 50f; 	//How fast the player can run
	public float jumpPower = 500f;	//How high the player can jump
	public bool grounded = true; 	//If the player is on the ground
	public int lives;

	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		//lives = 

	}

	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Velocity", Mathf.Abs(Input.GetAxis("Horizontal")));		

		if(Input.GetAxis("Horizontal") < -0.1f)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if(Input.GetAxis("Horizontal") > 0.1f)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		if (grounded == true) 
		{
			if (Input.GetButtonDown ("Jump") && grounded) {
				rb2d.AddForce (Vector2.up * jumpPower);
			}
		}
	}

	void FixedUpdate()
	{
		//Used to get left and right arrow and button A & D
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		//h just determines the direction of the player because h is either
		//positive or negative 1
		rb2d.AddForce((Vector2.right * velocity) * h);
		rb2d.AddForce ((Vector2.up * velocity) * v);
		//Character Speed regulation
		if(rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if(rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
//		if (rb2d.velocity.y > maxSpeed) 
//		{
//			rb2d.velocity = new Vector2 (rb2d.velocity.x, maxSpeed);
//		}
//		if (rb2d.velocity.y < -maxSpeed)
//		{
//			rb2d.velocity = new Vector2 (rb2d.velocity.x, maxSpeed);	
//		}
		//Code for if I want to allow player to fly anywhere without bounds
		// float j = Input.GetAxis ("Vertical");
		// rb2d.AddForce((Vector2.up * jumpPower) * j);

	}
}
