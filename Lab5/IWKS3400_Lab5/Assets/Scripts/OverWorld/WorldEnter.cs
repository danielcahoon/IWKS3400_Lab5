using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WorldEnter : MonoBehaviour {

	public string newGameLevel;
	public GameObject gameObject;
	public int worldNumber;

	private Animator anim;


	public void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			if (Input.GetKey (KeyCode.E)) {
				if (worldNumber != 3) {
					SceneManager.LoadScene (newGameLevel);
				} else {
					anim.SetBool ("BossDoorOpen", true);
				}
			}
			gameObject.SetActive (true);
		}
	}
	public void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			if (Input.GetKey (KeyCode.E)) {
				if (worldNumber != 3) {
					SceneManager.LoadScene (newGameLevel);
				} else {
					anim.SetBool ("BossDoorOpen", true);
				}
			}
			gameObject.SetActive (true);
		}
	}
	public void OnTriggerExit2D(Collider2D col)
	{
		gameObject.SetActive (false);
	}
}
