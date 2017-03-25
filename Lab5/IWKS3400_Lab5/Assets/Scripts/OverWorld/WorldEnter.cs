using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WorldEnter : MonoBehaviour {

	public string newGameLevel;
	public GameObject gameObject;

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (Input.GetKey(KeyCode.E)) 
		{
			SceneManager.LoadScene (newGameLevel);
		}
		gameObject.SetActive (true);
	}
	public void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKey(KeyCode.E)) 
		{
			SceneManager.LoadScene (newGameLevel);
		}
		gameObject.SetActive (true);
	}
	public void OnTriggerExit2D(Collider2D col)
	{
		gameObject.SetActive (false);
	}
}
