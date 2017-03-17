using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldChanger : MonoBehaviour
{
	public string newGameLevel;

	public void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("OnTriggerEnter : col.tag = " + col.tag); // shows the tag of the trigger
		if (col.CompareTag("Ash"))
		{
			SceneManager.LoadScene(newGameLevel);
		}
	}
}