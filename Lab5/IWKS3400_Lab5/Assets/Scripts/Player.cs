using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject gameObject;

	//Floats
	public float maxSpeed = 3f;		//Maximum speed we will allow the player to go
	public Vector2 friction = new Vector2(10f, 49f);
	public float velocity = 50f; 	//How fast the player can run
	public float jumpPower = 1000f;	//How high the player can jump

	//Bools
	public bool grounded = true; 	//If the player is on the ground
	public bool canDoubleJump;
	public bool canTripleJump;
	public bool canQuadJump;
	public bool goingRight = false;
	public bool goingLeft = false;
	public bool idle = true;

	public AudioClip soundEffect;

	//Ints
	public int lives;
	public int characterType;
	public int playerPrefCharacterSkin;

	//Strings
	public string gameLevel;

	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource audioSource;
	public GameObject character;

	// Use this for initialization
	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		Physics2D.gravity = new Vector2 (0f, -9.81f);
		audioSource = gameObject.GetComponent<AudioSource> ();
		lives = PlayerPrefs.GetInt ("PlayerLives");
		playerPrefCharacterSkin = PlayerPrefs.GetInt ("CharacterSkin");

	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Velocity", Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool ("Left", goingLeft);
		anim.SetBool ("Right", goingRight);
		anim.SetBool ("Idle", idle);
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
			//audioSource.PlayOneShot (soundEffect, 1);
		}
	}

	void FixedUpdate()
	{
		if (characterType != playerPrefCharacterSkin) {
			character.SetActive (false);
		}	
		//Used to get left and right arrow and button A & D
		float h = Input.GetAxis("Horizontal");
		rb2d.AddForce((Vector2.right * velocity) * h);
		rb2d.AddForce((Vector2.left * friction.x) * h);
		if (rb2d.velocity.x < 0) 
		{
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}
		if(rb2d.velocity.x > 0 && h > 0)
		{
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}
		Debug.Log (h);
		if (h > 0) {
			goingRight = true;
			idle = false;
		} else if (h == 0) {
			goingRight = false;
			goingLeft = false;
			idle = true;
		} else {
			goingLeft = true;
			idle = false;
		}
		//h just determines the direction of the player because h is either
		//positive or negative 1

	}
}
