﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillPlayer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			PlayerDeathManagement.Die();
		}
	}
}
