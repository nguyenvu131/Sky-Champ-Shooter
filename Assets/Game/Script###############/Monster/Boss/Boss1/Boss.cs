using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int level = 1;
    public BossStats stats = new BossStats();

    private float currentHP;

    void Start()
    {
        stats.CalculateStats(level);
        currentHP = stats.HP;

        Debug.Log("Boss Level " + level + " | HP: " + stats.HP + " | ATK: " + stats.ATK);
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = Mathf.Max(1, damage - stats.DEF);
        currentHP -= actualDamage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss died. Drop " + stats.ExpDrop + " EXP and " + stats.GoldDrop + " Gold");
        // Gọi DropItemPoolManager.SpawnItem() nếu có
        Destroy(gameObject);
    }
}
