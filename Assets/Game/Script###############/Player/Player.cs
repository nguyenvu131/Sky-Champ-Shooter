using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player  : MonoBehaviour, IDamageable
{
	public static Player Instance;
	
	// public static PlayerData Instance;
	public int gold;
    public int gem;
	//////////////////////////////////
    public int level = 1;           // Cấp độ hiện tại của người chơi (hoặc nhân vật), bắt đầu từ level 1
	public int currentExp = 0;      // Kinh nghiệm (EXP) hiện có, dùng để tính lên cấp (level up)
	
	public PlayerStats stats;       // Tham chiếu đến script chứa chỉ số nhân vật như HP, ATK, DEF,... (struct/class chứa các stats)
	public PlayerData data;         // Dữ liệu người chơi lưu trữ dài hạn (level, exp, chỉ số, kỹ năng, trang bị...)
	public PlayerLevelSystem levelSystem;
	public PlayerStatsUI playerStatsUI;
	
	
	void Awake()
    {
        if (Instance == null)
            Instance = this;
		
    }
	
    void Start()
    {
        LoadStats(level);
		stats.currentHP = stats.maxHP;
		
    }
	
	void Update()
	{
		
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

    protected  void Die()
    {
        Debug.Log("Player chết!");
		// levelSystem.GainExp(100);
	

        // Thêm xử lý chết tại đây (hiệu ứng, reload scene, game over...)
        gameObject.SetActive(false);
    }
	
	public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("AddGold: " + amount + ", Total: " + gold);
    }

    public void AddGem(int amount)
    {
        gem += amount;
        Debug.Log("AddGem: " + amount + ", Total: " + gem);
    }
	
}
