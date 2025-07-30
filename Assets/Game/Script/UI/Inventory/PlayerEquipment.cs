using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {

	public EquipmentData weapon;
    public EquipmentData armor;
    public EquipmentData drone;
    public EquipmentData pet;

    public void EquipItem(EquipmentData equip)
    {
        switch (equip.type)
        {
            case EquipmentType.Weapon:
                weapon = equip;
                break;
            case EquipmentType.Armor:
                armor = equip;
                break;
            case EquipmentType.Drone:
                drone = equip;
                break;
            case EquipmentType.Pet:
                pet = equip;
                break;
        }
    }

    public void Unequip(EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.Weapon: weapon = null; break;
            case EquipmentType.Armor: armor = null; break;
            case EquipmentType.Drone: drone = null; break;
            case EquipmentType.Pet: pet = null; break;
        }
    }

    public int GetTotalAttack()
    {
        int total = 0;
        if (weapon != null) total += weapon.attack;
        if (drone != null) total += drone.attack;
        return total;
    }

    public int GetTotalDefense()
    {
        int total = 0;
        if (armor != null) total += armor.defense;
        return total;
    }

    public int GetTotalHP()
    {
        int total = 0;
        if (armor != null) total += armor.hp;
        if (pet != null) total += pet.hp;
        return total;
    }
}
