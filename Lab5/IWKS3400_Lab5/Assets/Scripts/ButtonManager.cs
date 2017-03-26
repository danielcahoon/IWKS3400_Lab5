//Code for button functionality from
//https://www.youtube.com/watch?v=FrJogRBSzFo

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public void NewGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene(newGameLevel);
	}

	public void ExitGameBtn()
	{
		Application.Quit ();
	}
}