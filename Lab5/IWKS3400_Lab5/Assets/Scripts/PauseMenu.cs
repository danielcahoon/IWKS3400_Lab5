using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {
	public GameObject pauseUI;

	private bool paused = false;

	void Start()
	{
		pauseUI.SetActive (false);
	}

	void Update()
	{
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			pauseUI.SetActive (true);
			Time.timeScale = 0;
		} else {
			pauseUI.SetActive (false);
			Time.timeScale = 1;
		}

	}
	public void Resume()
	{
		paused = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene (Application.loadedLevel);
	}
	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenuScene");
	}
	public void QuitGame()
	{
		Application.Quit ();
	}
}
