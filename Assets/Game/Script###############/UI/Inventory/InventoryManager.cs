using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    public EquippedSlots equippedSlots = new EquippedSlots();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Thêm item
    public void AddItem(string itemID, ItemType itemType, int quantity)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        if (item != null)
        {
            item.quantity += quantity;
        }
        else
        {
            inventory.Add(new InventoryItem(itemID, itemType, quantity));
        }
    }

    // Xóa item
    public void RemoveItem(string itemID, int quantity)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        if (item == null) return;

        item.quantity -= quantity;
        if (item.quantity <= 0)
        {
            inventory.Remove(item);
        }
    }

    // Trang bị item
    public void EquipItem(string itemID)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        if (item == null) return;

        switch (item.itemType)
        {
            case ItemType.Weapon:
                equippedSlots.equippedWeaponID = itemID;
                break;
            case ItemType.Pet:
                equippedSlots.equippedPetID = itemID;
                break;
            case ItemType.Drone:
                equippedSlots.equippedDroneID = itemID;
                break;
            case ItemType.Equipment:
                if (!equippedSlots.equippedEquipments.Contains(itemID))
                    equippedSlots.equippedEquipments.Add(itemID);
                break;
        }

        item.isEquipped = true;
    }

    // Bỏ trang bị
    public void UnequipItem(string itemID)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        if (item == null) return;

        switch (item.itemType)
        {
            case ItemType.Weapon:
                if (equippedSlots.equippedWeaponID == itemID)
                    equippedSlots.equippedWeaponID = null;
                break;
            case ItemType.Pet:
                if (equippedSlots.equippedPetID == itemID)
                    equippedSlots.equippedPetID = null;
                break;
            case ItemType.Drone:
                if (equippedSlots.equippedDroneID == itemID)
                    equippedSlots.equippedDroneID = null;
                break;
            case ItemType.Equipment:
                equippedSlots.equippedEquipments.Remove(itemID);
                break;
        }

        item.isEquipped = false;
    }

    // Khóa / Mở khóa item
    public void ToggleLock(string itemID)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        if (item != null)
            item.isLocked = !item.isLocked;
    }

    // Kiểm tra xem item đã được trang bị chưa
    public bool IsEquipped(string itemID)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        return item != null && item.isEquipped;
    }

    // Tìm tất cả item theo loại
    public List<InventoryItem> GetItemsByType(ItemType type)
    {
        return inventory.FindAll(i => i.itemType == type);
    }
}
