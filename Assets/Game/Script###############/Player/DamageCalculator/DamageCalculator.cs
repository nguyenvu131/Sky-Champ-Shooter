using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculator
{
	 
    public static float CalculateDamage(DamageInfo info, float targetDefense)
    {
        float rawDamage = info.baseDamage + info.weaponAttack + info.bonusAttack;

        // Tính crit
        bool isCritical = Random.value < info.critChance;
        float critBonus = isCritical ? info.critMultiplier : 1f;

        float totalDamage = rawDamage * critBonus * info.damageMultiplier - info.defense;

        return Mathf.Max(1f, totalDamage); // luôn gây ít nhất 1 damage
    }
}
