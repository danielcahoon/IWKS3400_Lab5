using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpType1 : MonoBehaviour {

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
	}

	void FixedUpdate()
	{
		rb2d.AddForce(Vector2.right * velocity);

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
}
