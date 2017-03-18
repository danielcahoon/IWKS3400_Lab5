using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour {
	public float velocityH = 50f;
	public float velocityV = 50f;
	public GameObject platform;

	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		Physics2D.gravity = Vector2.zero;
	}

	void FixedUpdate()
	{
		//Used to get left and right arrow and button A & D
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		//h just determines the direction of the player because h is either
		//positive or negative 1
		transform.position = new Vector3(transform.position.x + velocityH * h, transform.position.y + velocityV * v, 0);

//		rb2d.AddForce((Vector2.right * velocityH) * h);
//		rb2d.AddForce ((Vector2.up * velocityV) * v);
//		if (platform.velocityH > maxSpeed) 
//		{
//			
//		}


	}
}
