using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageInfo
{
    
    public float attackPower;
    public float skillMultiplier = 1f;

    public float critChance = 0.1f;
    public float critMultiplier = 2f;

    public float elementalMultiplier = 1f;
    public float ignoreDefensePercent = 0f;

    public bool isCritical = false;

    // public DamageInfo(float baseDamage, float atkPower)
    // {
        // this.baseDamage = baseDamage;
        // this.attackPower = atkPower;
    // }
	
    public float attackStat;
	public float baseDamage = 100;
	public float weaponAttack = 50;
    public float bonusAttack = 30;
    public float damageMultiplier = 1.0f;
	public float defense;

    public DamageInfo(float baseDamage, float attackStat)
    {
        this.baseDamage = baseDamage;
        this.attackStat = attackStat;
    }
}
