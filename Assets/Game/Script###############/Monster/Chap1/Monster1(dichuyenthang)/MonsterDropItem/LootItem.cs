using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour {

	public int value = 10;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerCurrency.Instance.AddGold(value);
			Destroy(gameObject);
		}
	}
}
