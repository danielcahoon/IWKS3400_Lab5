using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowSnake : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.CompareTag ("Player")) {
            transform.localScale = new Vector3 (-1, 1, 1);
		}
	}
}
