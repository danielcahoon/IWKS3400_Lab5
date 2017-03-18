using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour {

	public GameObject powerUp;

	public void OnTriggerEnter2D(Collider2D col)
	{
		powerUp.SetActive(true);
	}

}
