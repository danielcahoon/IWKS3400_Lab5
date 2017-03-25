using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBossDoor : MonoBehaviour {


	private Animator anim;
	public string newGameLevel;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		anim.SetBool("BossDoorOpen", true);
	}

	void ChangeWorld ()
	{
		SceneManager.LoadScene (newGameLevel);

	}
}
