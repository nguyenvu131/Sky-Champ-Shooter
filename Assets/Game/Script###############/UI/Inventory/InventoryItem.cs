using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemID;
    public ItemType itemType;
    public int quantity = 1;
    public bool isEquipped = false;
    public bool isLocked = false;
    public int level = 1;
    public int star = 1;

    public InventoryItem(string id, ItemType type, int qty)
    {
        itemID = id;
        itemType = type;
        quantity = qty;
    }
}
