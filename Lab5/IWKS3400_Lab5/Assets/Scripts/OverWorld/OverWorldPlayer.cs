using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldPlayer : MonoBehaviour {

	public float maxSpeed = 3f;		//Maximum speed we will allow the player to go
	public float velocity = 50f; 	//How fast the player can run
	public float jumpPower = 500f;	//How high the player can jump

	//Bools for animation
	public bool grounded = true; 	//If the player is on the ground
	//Directional bools
	public bool goingUp = false;
	public bool goingDown = false;
	public bool goingRight = false;
	public bool goingLeft = false;
	public bool idle = true;

	public int lives;

	private Rigidbody2D rb2d;
	private Animator anim;
	public Vector2 gravity;

	// Use this for initialization
	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		gravity = Physics2D.gravity;
		Physics2D.gravity = Vector2.zero;
		//lives = 

	}

	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("Grounded", grounded);
		anim.SetBool ("Up", goingUp);
		anim.SetBool ("Down", goingDown);
		anim.SetBool ("Left", goingLeft);
		anim.SetBool ("Right", goingRight);
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
		if (v > 0) {
			goingUp = true;
		} else if (v < 0) {
			goingDown = true;
			goingUp = false;
			goingDown = false;
		} else {
			goingDown = true;
		}
		if (h > 0) {
			goingRight = true;
		} else if (h == 0) {
			goingRight = false;
			goingLeft = false;
		} else {
			goingLeft = true;
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
	public void scaleUp()
	{
		transform.localScale = new Vector3 (transform.localScale.x * 1.572067f, transform.localScale.y * 1.572067f, transform.localScale.z * 1.572067f);
	}
}
