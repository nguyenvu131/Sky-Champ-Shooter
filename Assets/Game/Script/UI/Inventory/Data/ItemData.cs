using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
	Weapon,
	Armor,
	Skill,
	Consumable,
	Material,
	Equipment,
	Quest,
	Currency
}



[System.Serializable]
public class ItemData {
	public int id;
	public string itemName;
	public Sprite icon;
	public string description;
	public ItemType type;
	public int quantity;

}
	

[System.Serializable]
public class ItemInstance
{
	public ItemData itemData;
	public int quantity;

	public ItemInstance(ItemData data, int amount)
	{
		itemData = data;
		quantity = amount;
	}
}