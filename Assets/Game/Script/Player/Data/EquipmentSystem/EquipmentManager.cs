using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    public static EquipmentManager Instance;

    public List<EquipmentSlot> equipmentSlots = new List<EquipmentSlot>();
    private PlayerStats playerStats;

    void Awake() {
        if (Instance == null) Instance = this;
    }

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerStats = player.GetComponent<PlayerStats>();
        }

        ApplyAllEquipments();
    }

    // Trang bị item vào slot tương ứng
    public bool Equip(EquipmentItem newItem) {
        for (int i = 0; i < equipmentSlots.Count; i++) {
            if (equipmentSlots[i].type == newItem.type) {
                equipmentSlots[i].equippedItem = newItem;
                ApplyAllEquipments();
                return true;
            }
        }
        return false;
    }

    // Gỡ bỏ trang bị theo loại
    public void Unequip(EquipmentType type) {
        for (int i = 0; i < equipmentSlots.Count; i++) {
            if (equipmentSlots[i].type == type) {
                equipmentSlots[i].equippedItem = null;
                ApplyAllEquipments();
                return;
            }
        }
    }

    // Trả về món trang bị đang mặc theo loại
    public EquipmentItem GetEquipped(EquipmentType type) {
        for (int i = 0; i < equipmentSlots.Count; i++) {
            if (equipmentSlots[i].type == type) {
                return equipmentSlots[i].equippedItem;
            }
        }
        return null;
    }

    // Áp dụng tất cả trang bị lên PlayerStats
    void ApplyAllEquipments() {
        if (playerStats == null) return;

        playerStats.InitStats(); // reset base stats

        for (int i = 0; i < equipmentSlots.Count; i++) {
            EquipmentItem item = equipmentSlots[i].equippedItem;
            if (item != null) {
                playerStats.maxHP += item.addHP;
                playerStats.attack += item.addATK;
                playerStats.defense += item.addDEF;
                playerStats.moveSpeed += item.addSPD;
                playerStats.fireRate += item.addFireRate;
                playerStats.critChance += item.addCrit;
            }
        }

        if (playerStats.currentHP > playerStats.maxHP) {
            playerStats.currentHP = playerStats.maxHP;
        }
    }

    // Trả về danh sách toàn bộ item đang trang bị
    public List<EquipmentItem> GetAllEquippedItems() {
        List<EquipmentItem> equippedList = new List<EquipmentItem>();
        for (int i = 0; i < equipmentSlots.Count; i++) {
            if (equipmentSlots[i].equippedItem != null) {
                equippedList.Add(equipmentSlots[i].equippedItem);
            }
        }
        return equippedList;
    }
}
