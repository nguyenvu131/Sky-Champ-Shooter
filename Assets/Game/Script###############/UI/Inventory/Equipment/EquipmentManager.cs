using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    // Danh sách tất cả trang bị người chơi sở hữu
    public List<EquipmentItem> ownedEquipments = new List<EquipmentItem>();

    // Slot đang được trang bị
    public Dictionary<EquipmentSlotType, EquipmentItem> equipped = new Dictionary<EquipmentSlotType, EquipmentItem>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (EquipmentSlotType type in System.Enum.GetValues(typeof(EquipmentSlotType)))
        {
            equipped[type] = null;
        }
    }

    // Trang bị một món
    public void Equip(string equipmentID)
    {
        EquipmentItem item = ownedEquipments.Find(e => e.equipmentID == equipmentID);
        if (item == null) return;

        EquipmentSlotType type = item.slotType;

        // Gỡ bỏ trang bị cũ nếu có
        if (equipped[type] != null)
            equipped[type].isEquipped = false;

        equipped[type] = item;
        item.isEquipped = true;
    }

    // Gỡ bỏ
    public void Unequip(EquipmentSlotType type)
    {
        if (equipped[type] != null)
        {
            equipped[type].isEquipped = false;
            equipped[type] = null;
        }
    }

    // Nhận stats cộng dồn
    public EquipmentStats GetTotalEquipmentStats()
    {
        EquipmentStats total = new EquipmentStats();

        foreach (KeyValuePair<EquipmentSlotType, EquipmentItem> pair in equipped)
        {
            if (pair.Value != null)
                total += pair.Value.stats;
        }

        return total;
    }

    // Thêm trang bị vào inventory
    public void AddEquipment(string id, EquipmentSlotType type, EquipmentStats stats)
    {
        EquipmentItem newItem = new EquipmentItem(id, type);
        newItem.stats = stats;
        ownedEquipments.Add(newItem);
    }

    // Xóa trang bị
    public void RemoveEquipment(string id)
    {
        EquipmentItem item = ownedEquipments.Find(e => e.equipmentID == id);
        if (item == null) return;

        if (item.isEquipped)
            Unequip(item.slotType);

        ownedEquipments.Remove(item);
    }

    // Tìm tất cả theo loại
    public List<EquipmentItem> GetBySlotType(EquipmentSlotType type)
    {
        return ownedEquipments.FindAll(e => e.slotType == type);
    }
}
