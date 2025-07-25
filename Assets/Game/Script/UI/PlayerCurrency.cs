using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencyHome : MonoBehaviour {

	public int gold;
	public int gem;

	public bool HasEnough(CurrencyType type, int amount) {
		switch (type) {
		case CurrencyType.Gold: return gold >= amount;
		case CurrencyType.Gem: return gem >= amount;
		}
		return false;
	}

	public void Spend(CurrencyType type, int amount) {
		switch (type) {
		case CurrencyType.Gold: gold -= amount; break;
		case CurrencyType.Gem: gem -= amount; break;
		}
	}
}
