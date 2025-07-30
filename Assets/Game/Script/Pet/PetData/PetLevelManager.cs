using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetLevelManager : MonoBehaviour
{
    public PetStats stats;

    void Start()
    {
        UpdatePetStat();
    }

    public void GainExp(int amount)
    {
        stats.currentExp += amount;
        while (stats.currentExp >= stats.expToNext && stats.level < 30)
        {
            stats.currentExp -= stats.expToNext;
            stats.level++;
            UpdatePetStat();
        }
    }

    void UpdatePetStat()
    {
        int lv = stats.level;

        // Damage
        if (lv <= 10)
            stats.damage = 10 + (lv - 1) * 2 + Mathf.FloorToInt(lv / 3);
        else if (lv <= 20)
            stats.damage = 34 + (lv - 10) * 4 + Mathf.FloorToInt((lv - 10) * 1.5f);
        else
            stats.damage = 85 + (lv - 20) * 7 + Mathf.FloorToInt((lv - 20) * 1.8f);

        // Attack Speed
        stats.attackSpeed = 1.0f + (lv - 1) * 0.05f;

        // HP
        stats.hp = 100 + (lv - 1) * 10;

        // Skill Cooldown
        if (lv <= 25)
            stats.skillCooldown = Mathf.Max(10f - (lv - 1) * 0.2f, 5.0f);
        else
            stats.skillCooldown = Mathf.Max(5.0f - (lv - 25) * 0.1f, 3.0f);

        // EXP To Next
        if (lv <= 10)
            stats.expToNext = 50 + (lv - 1) * 10 + Mathf.FloorToInt(lv * 1.5f);
        else if (lv <= 20)
            stats.expToNext = 180 + (lv - 10) * 30 + Mathf.FloorToInt(Mathf.Pow(lv - 10, 1.2f)) * 5;
        else
            stats.expToNext = 600 + Mathf.FloorToInt(Mathf.Pow(lv - 20, 1.5f)) * 80;
    }
}
