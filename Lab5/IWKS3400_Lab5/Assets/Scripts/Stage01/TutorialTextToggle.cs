using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextToggle : MonoBehaviour {


	public GameObject text;

	public void OnTriggerEnter2D(Collider2D col)
	{
		text.SetActive(true);
	}
	public void OnTriggerStay2D(Collider2D col)
	{
		text.SetActive(true);
	}
	public void OnTriggerExit2D(Collider2D col)
	{
		text.SetActive (false);
	}
}
