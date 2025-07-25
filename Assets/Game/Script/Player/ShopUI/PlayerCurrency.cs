using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour {

	public static PlayerCurrency Instance;

	public int gold = 1000;

	void Awake()
	{
		Instance = this;
	}

	public bool SpendGold(int amount)
	{
		if (gold >= amount)
		{
			gold -= amount;
			return true;
		}
		return false;
	}

	public void AddGold(int amount)
	{
		gold += amount;
	}
}
