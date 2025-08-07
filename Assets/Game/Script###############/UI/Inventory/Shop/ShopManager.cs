using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public List<ShopItem> shopItems = new List<ShopItem>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Tạo dữ liệu mẫu
        CreateTestItems();
    }

    void CreateTestItems()
    {
        ShopItem sword = new ShopItem("sword_basic", "Basic Sword", ItemType.Weapon, 300);
        sword.stats = new EquipmentStats { addAttack = 10 };
        sword.equipmentSlot = EquipmentSlotType.Accessory;

        ShopItem ring = new ShopItem("ring_hp", "Ring of HP", ItemType.Equipment, 200);
        ring.stats = new EquipmentStats { addHP = 100 };
        ring.equipmentSlot = EquipmentSlotType.Ring;

        shopItems.Add(sword);
        shopItems.Add(ring);
    }

    public void BuyItem(ShopItem item)
    {
        if (PlayerGoldManager.Instance.SpendGold(item.price))
        {
            if (item.itemType == ItemType.Equipment)
            {
                EquipmentManager.Instance.AddEquipment(item.itemID, item.equipmentSlot, item.stats);
            }
            else
            {
                InventoryManager.Instance.AddItem(item.itemID, item.itemType, 1);
            }

            Debug.Log("Mua thành công: " + item.displayName);
        }
        else
        {
            Debug.Log("Không đủ vàng!");
        }
    }
}