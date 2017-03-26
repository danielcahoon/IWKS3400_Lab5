using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	//Floats
	public float maxSpeed = 3f;		//Maximum speed we will allow the player to go
	public float velocity = 50f; 	//How fast the player can run
	public float jumpPower = 100f;	//How high the player can jump

	//Bools
	public bool grounded = true; 	//If the player is on the ground
	public bool canDoubleJump;
	public bool canTripleJump;
	public bool canQuadJump;

	//Ints
	public int lives;

	//Strings
	public string gameLevel;

	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		Physics2D.gravity = new Vector2 (0f, -9.81f);
		lives = 3;

	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Velocity", Mathf.Abs(Input.GetAxis("Horizontal")));		

		if (lives == 0)
		{
			SceneManager.LoadScene (gameLevel);
		}
			
		if(Input.GetAxis("Horizontal") < -0.1f)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if(Input.GetAxis("Horizontal") > 0.1f)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		if (Input.GetButtonDown ("Jump")) {
			if (grounded) {
				rb2d.AddForce (Vector2.up * jumpPower);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					rb2d.AddForce (Vector2.up * jumpPower);
					canTripleJump = true;
				} else {
					if (canTripleJump) {
						canTripleJump = false;
						rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
						rb2d.AddForce (Vector2.up * jumpPower);
						canQuadJump = true;
					} else {
						if (canQuadJump) {
							canQuadJump = false;
							rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
							rb2d.AddForce (Vector2.up * jumpPower);
						}
					}
				}
			}
		}
	}

	void FixedUpdate()
	{
		//Used to get left and right arrow and button A & D
		float h = Input.GetAxis("Horizontal");

		//h just determines the direction of the player because h is either
		//positive or negative 1
		rb2d.AddForce((Vector2.right * velocity) * h);

		//Character Speed regulation
		if(rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if(rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}


		//Code for if I want to allow player to fly anywhere without bounds
		// float j = Input.GetAxis ("Vertical");
		// rb2d.AddForce((Vector2.up * jumpPower) * j);

	}
}
