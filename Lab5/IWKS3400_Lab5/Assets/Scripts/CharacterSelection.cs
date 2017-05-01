using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour {
	public int characterType;

	public void NewGameBtn(string newGameLevel)
	{
		PlayerPrefs.SetInt ("CharacterSkin", characterType);
		SceneManager.LoadScene(newGameLevel);
	}
}
