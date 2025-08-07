using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItem", menuName = "Equipment/Create New Equipment")]
public class EquipmentItemPlayer : ScriptableObject
{
    public string equipmentID;
    public string equipmentName;
    public Sprite icon;
    public int power;
    public int level;
    public int upgradeCost;
}

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Create New Player Data")]
public class PlayerData : ScriptableObject
{
	public string playerName;
    public int level = 1;
    public int exp = 0;
    public int coin = 0;
	public int gold = 0;
    public int gem = 0;
	
	[Header("Base Stats")]
    public int baseHP = 100;
    public int baseAttack = 20;
    public int baseDefense = 10;

    [Header("Level Scaling")]
    public AnimationCurve hpCurve;
    public AnimationCurve atkCurve;
    public AnimationCurve defCurve;

    [Header("Equipped")]
    public PetData equippedPet;

    [Header("Inventory")]
    public PetData[] ownedPets;
    public SkillData[] ownedSkills;
	
	public List<string> unlockedWeapons = new List<string>();
    public List<string> unlockedSkills = new List<string>();

    public Dictionary<string, int> weaponLevels = new Dictionary<string, int>();
    public Dictionary<string, int> skillLevels = new Dictionary<string, int>();
	
	public void AddGold(int amount)
    {
        gold += amount;
    }

    public void AddWeapon(string weaponName)
    {
        if (!unlockedWeapons.Contains(weaponName))
            unlockedWeapons.Add(weaponName);
    }

    public void UpgradeWeapon(string weaponName)
    {
        if (!weaponLevels.ContainsKey(weaponName))
            weaponLevels[weaponName] = 1;
        else
            weaponLevels[weaponName]++;
    }

    public int GetWeaponLevel(string weaponName)
    {
        return weaponLevels.ContainsKey(weaponName) ? weaponLevels[weaponName] : 1;
    }
	
	
}
