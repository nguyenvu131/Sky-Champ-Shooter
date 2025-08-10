using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public string itemID;
    public string displayName;
    public ItemType itemType;
    public EquipmentSlotType equipmentSlot;
    public int price;
    public EquipmentStats stats; // nếu là Equipment

    public ShopItem(string id, string name, ItemType type, int gold)
    {
        itemID = id;
        displayName = name;
        itemType = type;
        price = gold;
    }
}
