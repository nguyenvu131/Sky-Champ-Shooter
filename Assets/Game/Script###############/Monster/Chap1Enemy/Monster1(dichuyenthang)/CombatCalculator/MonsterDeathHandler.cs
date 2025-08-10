using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeathHandler : MonoBehaviour {

	public GameObject lootPrefab;

	public void HandleDeath()
	{
		// Drop loot
		if (lootPrefab)
		{
			Instantiate(lootPrefab, transform.position, Quaternion.identity);
		}

		// Gửi sự kiện cho hệ thống mission/score
//		EventManager.Trigger("ENEMY_KILLED");
	}
}
