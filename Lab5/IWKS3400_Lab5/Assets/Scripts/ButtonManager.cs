//Code for button functionality from
//https://www.youtube.com/watch?v=FrJogRBSzFo

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public int playerLives;
	public int character;

	public void NewGameBtn(string newGameLevel)
	{
		PlayerPrefs.SetInt ("PlayerLives", playerLives);
		PlayerPrefs.SetInt ("Character", character);
		SceneManager.LoadScene(newGameLevel);
	}

	public void ExitGameBtn()
	{
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}

	public void ChooseCharacter(int character)
	{
		PlayerPrefs.SetInt ("CharacterSkin", character);
	}
}