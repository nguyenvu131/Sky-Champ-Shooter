﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			// Gọi PlayerStats.AddCoin(), AddHP(), AddMP(), etc.
			Destroy(gameObject);
		}
	}
}
