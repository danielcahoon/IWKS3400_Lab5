using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrationSceneChanger : MonoBehaviour {
	public float timeSpent;

	void FixedUpdate()
	{
		if (timeSpent >= 44.5) {
			SceneManager.LoadScene ("Overworld");
		}

		timeSpent += Time.deltaTime;
	}
}
