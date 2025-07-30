using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity { Common, Rare, Epic, Legendary }
public enum CurrencyTypeHome { Gold, Gem }

[System.Serializable]
public class ShopItem {
	public string itemName;
	public int levelRequirement;
	public Rarity rarity;
	public float typeMultiplier;
	public int upgradeLevel;
	public CurrencyType currencyType;

	public int GetBasePrice() {
		float rarityMultiplier = GetRarityMultiplier(rarity);
		return Mathf.RoundToInt(rarityMultiplier * Mathf.Pow(levelRequirement, 1.2f) * typeMultiplier);
	}

	public int GetUpgradePrice() {
		return Mathf.RoundToInt(GetBasePrice() * Mathf.Pow(upgradeLevel, 1.5f));
	}

	public int GetFinalPrice(float discountPercent) {
		return Mathf.RoundToInt(GetBasePrice() * (1f - discountPercent / 100f));
	}

	float GetRarityMultiplier(Rarity r) {
		switch (r) {
		case Rarity.Common: return 1f;
		case Rarity.Rare: return 1.5f;
		case Rarity.Epic: return 2f;
		case Rarity.Legendary: return 3f;
		}
		return 1f;
	}
}
