using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {
	public GameObject pauseUI;
	public GameObject canvasToFade;

	private bool paused = false;

	void Start()
	{
		pauseUI.SetActive (false);
	}

	void Update()
	{
		if (Input.GetKeyDown ("return")) {
			SceneManager.LoadScene ("NewLoadGameScene");
		}

		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			pauseUI.SetActive (true);
			canvasToFade.SetActive (false);
			Time.timeScale = 0;
		} else {
			pauseUI.SetActive (false);
			canvasToFade.SetActive (true);
			Time.timeScale = 1;
		}

	}
	public void Resume()
	{
		paused = false;
		canvasToFade.SetActive (true);
	}

	public void Restart()
	{
		SceneManager.LoadScene (Application.loadedLevel);
	}
	public void MainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenuScene");
	}
	public void QuitGame()
	{
		Application.Quit ();
	}
		
}
