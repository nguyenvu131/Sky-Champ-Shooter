using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
	public int currentExp = 0;
    public PlayerStats stats;

    void Start()
    {
        LoadStats(level);
		stats.currentHP = stats.maxHP;
		
    }

    void LoadStats(int lv)
    {
        int currentPoints = stats != null ? stats.StatPoints : 0;
		stats = new PlayerStats(lv, currentPoints);
		
        // Debug.Log("Player Level: " + stats.Level);
        // Debug.Log("HP: " + stats.HP + ", ATK: " + stats.ATK + ", SPD: " + stats.SPD);
    }
	
	public void GainEXP(float amount)
    {
        stats.currentEXP += amount;

        while (stats.currentEXP >= stats.expToNextLevel)
        {
            stats.currentEXP -= stats.expToNextLevel;
            LevelUp();
        }
    }
	
    public void LevelUp()
    {
        // currentExp -= stats.ExpToNextLevel;
		level++;
		
        LoadStats(level);
		stats.maxHP += 20;
        stats.attack += 5;
        stats.defense += 2;
        stats.expToNextLevel += 50;
        stats.currentHP = stats.maxHP;
		
		// +3 điểm mỗi level
		int extraStat = 3;
		int currentPoints = stats != null ? stats.StatPoints : 0;

		stats = new PlayerStats(level, currentPoints + extraStat);
    }
	
	public void TakeDamage(float damage)
    {
        stats.currentHP -= stats.damage;
		stats.hp -= damage;
		
        if (stats.currentHP <= 0 || stats.hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player chết!");
		GainEXP(25);
        // Thêm xử lý chết tại đây (hiệu ứng, reload scene, game over...)
        gameObject.SetActive(false);
    }
}
