using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeathManagement : MonoBehaviour {

	void OnTrigger2DEnter(Collider2D col)
	{
		if(col.CompareTag("Enemy"))
		{
			Die();
		}

	}

	public static void Die()
	{
		int playerLives = PlayerPrefs.GetInt ("PlayerLives");

		//Restart stage
		playerLives--;
		PlayerPrefs.SetInt ("PlayerLives", playerLives);
		SceneManager.LoadScene(Application.loadedLevel);
	}
}
