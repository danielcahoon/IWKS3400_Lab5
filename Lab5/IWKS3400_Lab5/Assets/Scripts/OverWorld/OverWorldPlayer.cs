using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverWorldPlayer : MonoBehaviour {

	//Velocity vectors
	public Vector2 velocity = new Vector2(500f, 500f);
	public Vector2 friction = new Vector2(0.01f, 0.01f);

	//Directional bools
	public bool goingUp = false;
	public bool goingDown = false;
	public bool goingRight = false;
	public bool goingLeft = false;
	public bool idle = true;

	//Misc Variables
	public GameObject character;
	private Rigidbody2D rb2d;
	private Animator anim;
	public int characterType;
	public int playerPrefCharacterSkin;

	// Use this for initialization
	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		Physics2D.gravity = Vector2.zero;
		playerPrefCharacterSkin = PlayerPrefs.GetInt ("CharacterSkin");
	}

	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("Up", goingUp);
		anim.SetBool ("Down", goingDown);
		anim.SetBool ("Left", goingLeft);
		anim.SetBool ("Right", goingRight);
		anim.SetBool ("Idle", idle);

	}

	void FixedUpdate()
	{
		if (characterType != playerPrefCharacterSkin) {
			character.SetActive (false);
		}	
		//Used to get up,down,right, and left arrows and buttons WASD
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");

		//h just determines the direction of the player because h is either
		//positive or negative 1
		rb2d.AddForce((Vector2.right * velocity.x) * h);
		rb2d.AddForce((Vector2.left * friction.x) * h);
		rb2d.AddForce ((Vector2.up * velocity.y) * v);
		rb2d.AddForce((Vector2.down * friction.y) * v);
		if (rb2d.velocity.x < 0) 
		{
			rb2d.velocity = Vector2.zero;
		}
		if (rb2d.velocity.y < 0) 
		{
			rb2d.velocity = Vector2.zero;
		}
		if(rb2d.velocity.x > 0 && h > 0)
		{
			rb2d.velocity = Vector2.zero;
		}
		if(rb2d.velocity.y > 0 && v > 0)
		{
			rb2d.velocity = Vector2.zero;
		}

		//Directional input bools

		if (Input.GetKeyDown(KeyCode.D)) {
			//Right
			goingRight = true;
			goingUp = false;
			goingLeft = false;
			goingDown = false;
			idle = false;
		}
		else if(Input.GetKeyDown(KeyCode.A)){
			//Left
			goingRight = false;
			goingUp = false;
			goingLeft = true;
			goingDown = false;
			idle = false;
		}
		else if(Input.GetKeyDown(KeyCode.W)){
			//Up
			goingRight = false;
			goingUp = true;
			goingLeft = false;
			goingDown = false;
			idle = false;
		}
		else if(Input.GetKeyDown(KeyCode.S)){
			//Down
			goingRight = false;
			goingUp = false;
			goingLeft = false;
			goingDown = true;
			idle = false;
		}

		else if (velocity == Vector2.zero) {
			idle = true;
		}
		
	}
}