using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton dùng cho trong Space Shooter RPG
//Singleton quản lý	Mô tả chức năng cụ thể
//GameManager	 Quản lý trạng thái tổng thể của game (Start, Pause, GameOver, Level Complete...).
//PlayerManager	 Quản lý chỉ số người chơi: HP, Shield, Energy, kỹ năng...
//UIManager	     Giao tiếp với các hệ thống UI: update máu, năng lượng, thông báo...
//AudioManager	 Điều khiển nhạc nền, âm thanh hiệu ứng, mute/unmute toàn game.
//SpawnManager	 Điều khiển việc sinh quái, vật phẩm, boss trong các màn chơi.
//SkillManager	 Quản lý kỹ năng chủ động & bị động, cooldown, hiệu ứng kỹ năng.
//EnemyManager	 Điều phối hành vi quái và AI.
//DataManager	 Lưu trữ và đọc dữ liệu player (level, save/load, config vũ khí...)
//ObjectPoolManager	Tái sử dụng đạn, quái, hiệu ứng để tối ưu hiệu suất.
//UpgradeManager	Quản lý nâng cấp vũ khí, tàu, kỹ năng.
//LootManager	    Tính toán vật phẩm rơi, kinh nghiệm và phần thưởng.

//HP (Sinh lực)	Máu – chết khi về 0
//MP (Nội lực)	Dùng để thi triển võ học
//ATK (Ngoại công)	Sát thương vật lý
//INT (Nội công)	Sát thương kỹ năng nội công
//DEF (Phòng thủ)	Giảm sát thương nhận vào
//AGI (Nhanh nhẹn)	Né tránh, tốc đánh, tốc độ di chuyển
//VIT (Thể chất)	Tăng HP tối đa
//WIS (Tâm pháp)	Tăng MP và hiệu quả nội công


[System.Serializable]
public class PlayerStats  
{
	public static PlayerStats Instance;
	
	[Header("Cấp & EXP")]
	public int level = 1;
	public int gold = 100;
	public int gem = 100;
	public int exp = 0;
	public float currentEXP;
	public float expToNextLevel = 100f;
	public int maxexp = 100;
	public int maxHP = 1000;
	public int maxMP = 1000;
	public float currentHP = 100;
	public float currentMP = 100;
	public float speed = 5;
	public int statPoints = 0;
	public int skillPoints = 3;
	
	[Header("Chỉ số cơ bản")]
	public float hp = 100;
	public int mp = 100;
	public int atk = 100;
	public int matk = 100;
	public int mdef = 100;
	public int str = 10;
	public int intel = 10;
	public int def = 50;
	public int agi = 10;
	public int dex = 10;
	public int vit = 10;
	public int wis = 10;
	public float defense;
	
	[Header("Chỉ số phụ")]
	public int chinhxac = 100;
	public int crit = 100;
	public int accuracy = 10;
	public int evasion = 10;
	public int dodge = 5;
	public int hitrate = 5; 
	//
	[Header("Chỉ số phụ")]
	public int baseHp;
	public int baseMP;
	public int baseATK;
	public int baseDEF;
	public int baseAGI;
	public int baseVIT;
	public int baseAccuracy;
	public int baseEvasion;
	//
	public int baseStrength;
	public int baseDexterity;
	public int baseVitality;
	public int baseIntelligence;
	
	[Header("chi so co ban")]
	public int baseHealth;
	public int baseMana;
	public int baseDefense;
	public float baseAttackSpeed;
	
	[Header("chi so damage")]
	public float damage;
	public float fireRate;
	public float critChance;
	public float critMultiplier;

	[Header("chi so nang luong")]
	public float dodgeChance;
	public float energy;
	public float energyRegen;
	//
	public float magnetRange;
	public float hpRegen;
	public float cooldownReduction;
	//
	public int bonusATK;
	public int bonusDEF;

	// Bonus Stats
	public float critRate = 10;     // %
	public int critDamage = 150;  // %
	public int armorPen = 0;      // %
	public int lifesteal = 0;     // %

	//Kháng nguyên tố & nội công
	public int resistFire;
	public int resistIce;
	public int resistPoison;
	public int innerPower; // Nội công

	//Skill
	public string skillName;
	public int mpCost;
	public float cooldown;

	//
	public int strength;
	public int dexterity;
	public int vitality;
	public int intelligence;

	// Base stats
	public float baseHP = 100f;
	public float baseAttack = 10f;
	public float baseFireRate = 1f;
	public float baseMoveSpeed = 5f;
	public float baseCritRate = 5f;
	public float baseCritDmg = 150f;

	// Final stats sau khi cộng
	public float finalHP;
	public float finalAttack;
	public float finalFireRate;
	public float finalMoveSpeed;
	public float finalCritRate;
	public float finalCritDmg;

	public float equipmentHPBonus;
	public float equipmentAttackBonus;
	public float buffCritRateBonus;

	public float attack = 10;
	public float attackSpeed = 1.0f;
	public float moveSpeed = 5f;
	public float shield = 50;

	public int baseExp;
	public int baseGold;
	public int expMultiplier;
	public int goldMultiplier;
	
	public int HP;
    public int ATK;
    public float DEF;
    public float SPD;
    public int EXPToLevelUp;
	// public int ExpToNextLevel;
	
	public int StatPoints; // điểm cộng chỉ số

	void Start()
	{
		//Diem chi so co ban
		InitStats();
	}

	public void GainExp(int amount) {
		exp += amount;
		if (exp >= ExpToNextLevel()) {
			LevelUp();
		}
	}

	public int ExpToNextLevel() {
		return 100 + (level - 1) * 50; // công thức cơ bản
	}
		
	public void LevelUp() {
		
		level++;
		statPoints += 5; // Mỗi cấp tăng 5 điểm
		damage += 2;
		exp = 0;
		maxHP += 20;
//		currentHP = maxHP;

		// Cộng thêm chỉ số cơ bản
		currentHP += 50;
		currentMP += 20;

		atk += 2;
		def += 1;
		agi += 1;
		vit += 1;
		str += 1;
		
		// nâng cấp chỉ số

	}

	public void InitStats()
	{
		currentHP = baseHP;
		currentMP = baseMP;

		atk = baseATK;
		def = baseDEF;
		agi = baseAGI;
		critRate = baseCritRate;
		accuracy = baseAccuracy;
		evasion = baseEvasion;

		str = baseStrength + strength;
		dex = baseDexterity + dexterity;
		vit = baseVitality + vitality;
		intel = baseIntelligence + intelligence;
	}

	public void AddStat(string stat, int value)
	{
		if (statPoints <= 0) return;

		switch (stat)
		{
		case "ATK": atk += value; break;
		case "DEF": def += value; break;
		case "AGI": agi += value; break;
		case "HP": currentHP += value; break;
		case "MP": currentMP += value; break;
		case "Crit": critRate += value; break;
		case "Accuracy": accuracy += value; break;
		case "Evasion": evasion += value; break;

		case "STR": strength++; break;
		case "DEX": dexterity++; break;
		case "VIT": vitality++; break;
		case "INT": intelligence++; break;
		}

		statPoints--;
	}

	public void ApplyBonus(PlayerStats stats)
	{
		stats.atk += bonusATK;
		stats.def += bonusDEF;
	}

	public void RemoveBonus(PlayerStats stats)
	{
		stats.atk -= bonusATK;
		stats.def -= bonusDEF;
	}

	public int CalculateDamage(PlayerStats attacker, PlayerStats defender)
	{
		int rawDamage = attacker.atk - defender.def;
		int damage = Mathf.Max(rawDamage, 1); // Không nhỏ hơn 1
		return damage;
	}

	public void Heal(int amount)
	{
		currentHP = Mathf.Min(currentHP + amount, maxHP);
	}

	public int CalculateCombatPower(PlayerStats stats)
	{
		float combatPower = 0;

		combatPower += stats.maxHP * 0.3f;
		combatPower += stats.atk * 1.8f;
		combatPower += stats.def * 1.5f;
		combatPower += stats.critRate * 2.0f;
		combatPower += stats.dodge * 1.5f;
		combatPower += stats.hitrate * 1.0f;
		//


		return Mathf.FloorToInt(combatPower);
	}


	//
	int GetExpForLevel(int level)
	{
		return Mathf.FloorToInt(100 * Mathf.Pow(level, 1.5f)); 
	}

	int GetExpForLevelHigh(int level)
	{
		return Mathf.FloorToInt(50 + 50 * level + (level * level * 2));
	}

	// Tổng chỉ số = cơ bản + theo cấp + từ trang bị + từ buff
		float GetFinalStat(float baseStat, float levelScale, int level, float equipmentBonus, float buffBonus)
	{
		return baseStat + (levelScale * level) + equipmentBonus + buffBonus;
	}


	//
	void RecalculateStats()
	{
		finalHP = baseHP + level * 10 + equipmentHPBonus;
		finalAttack = baseAttack + level * 2 + equipmentAttackBonus;
		finalFireRate = baseFireRate + level * 0.05f;
		finalMoveSpeed = baseMoveSpeed + level * 0.03f;

		finalCritRate = Mathf.Clamp(baseCritRate + buffCritRateBonus + level * 0.2f, 0, 100f);
		finalCritDmg = baseCritDmg + level * 1.5f;

		exp = Mathf.RoundToInt(baseExp * (1 + expMultiplier));
		gold = Mathf.RoundToInt(baseGold * (1 + goldMultiplier));
//		float dropChance = baseDropRate + formula.dropRateBonus;
	}
		
	public void TakeDamage(float amount)
	{
		currentHP -= amount;

		// Hiện popup text
		// PopupTextPoolManager.Instance.SpawnPopup(
			// "damage",
			// transform.position + Vector3.up * 1.5f,
			// amount.ToString()
		// );

		// Check chết
		if (currentHP <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		
		Debug.Log("Player Died!");
		// Thêm logic chết (disable control, UI, reload...)
		
		// gameObject.SetActive(false);
		
	}
	
	public PlayerStats(int level, int statPoints = 0)
    {
        this.level = level;
		StatPoints = statPoints;
        HP = 100 + (level - 1) * 20;
        ATK = 10 + (level - 1) * 2;
        DEF = 5 + (level - 1) * 1;
        SPD = 3.0f + (level - 1) * 0.05f;
        // ExpToNextLevel = 100 + (level - 1) * 50;
		

    }
	
	public void AddHP() { if (StatPoints > 0) { HP += 10; StatPoints--; } }
	public void AddATK() { if (StatPoints > 0) { ATK += 2; StatPoints--; } }
	public void AddDEF() { if (StatPoints > 0) { DEF += 1; StatPoints--; } }
	public void AddSPD() { if (StatPoints > 0) { SPD += 0.05f; StatPoints--; } }
}
