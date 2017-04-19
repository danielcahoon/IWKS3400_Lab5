using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {
	public void NewGameBtn(int characterType)
	{
		PlayerPrefs.SetInt ("CharacterSkin", characterType);
	}
}
