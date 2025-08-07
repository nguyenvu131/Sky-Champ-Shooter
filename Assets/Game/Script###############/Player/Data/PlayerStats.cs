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


[System.Serializable] // Cho phép class hiển thị và lưu trữ trong Unity Inspector/Serialization.
public class PlayerStats  
{
	public static PlayerStats Instance; // Singleton để truy cập thống nhất PlayerStats toàn game.
	
	[Header("Cấp & EXP")]
	public int level = 1;              // Cấp độ hiện tại của nhân vật
	public int gold = 100;            // Số vàng hiện có
	public int gem = 100;             // Số kim cương hiện có
	public int exp = 0;               // Tổng EXP tích lũy hiện tại
	public float currentEXP;         // EXP hiện tại trong cấp hiện tại
	public float expToNextLevel = 100f; // EXP cần để lên cấp tiếp theo
	public int maxexp = 100;         // EXP tối đa cho mỗi cấp (có thể dư ra để scale)
	public int maxHP = 1000;         // Máu tối đa
	public int maxMP = 1000;         // Mana tối đa
	public float currentHP = 100;    // Máu hiện tại
	public float currentMP = 100;    // Mana hiện tại
	public float speed = 5;          // Tốc độ di chuyển cơ bản
	public int statPoints = 0;       // Điểm cộng chỉ số khi lên cấp
	public int skillPoints = 3;      // Điểm cộng kỹ năng khi lên cấp
	
	[Header("Chỉ số cơ bản")]
	public float hp = 100;         // Lượng máu
	public int mp = 100;           // Mana
	public int atk = 100;          // Tấn công vật lý
	public int matk = 100;         // Tấn công phép
	public int mdef = 100;         // Kháng phép
	public int str = 10;           // Sức mạnh
	public int intel = 10;         // Trí tuệ
	public int def = 50;           // Phòng thủ vật lý
	public int agi = 10;           // Nhanh nhẹn
	public int dex = 10;           // Khéo léo
	public int vit = 10;           // Thể chất
	public int wis = 10;           // Khôn ngoan
	public float defense;          // Tổng chỉ số phòng thủ (cộng từ nhiều nguồn)
	
	[Header("Chỉ số phụ")]
	public int chinhxac = 100;     // Độ chính xác
	public int crit = 100;         // Tỉ lệ chí mạng
	public int accuracy = 10;      // Xác suất đánh trúng
	public int evasion = 10;       // Khả năng né
	public int dodge = 5;          // % né tránh
	public int hitrate = 5;        // % tỉ lệ đánh trúng 
	//
	[Header("Chỉ số phụ")]
	public int baseHp;             // Máu cơ bản (Hit Points)
	public int baseMP;             // Mana cơ bản (Magic Points)
	public int baseATK;            // Tấn công vật lý cơ bản (Attack)
	public int baseDEF;            // Phòng thủ vật lý cơ bản (Defense)
	public int baseAGI;            // Tốc độ / nhanh nhẹn (Agility), ảnh hưởng đến tốc độ tấn công hoặc né
	public int baseVIT;            // Thể lực (Vitality), ảnh hưởng đến HP và phòng thủ
	public int baseAccuracy;       // Độ chính xác, ảnh hưởng đến khả năng đánh trúng mục tiêu
	public int baseEvasion;        // Né tránh, ảnh hưởng đến khả năng né đòn của đối phương
	public int baseStrength;       // Sức mạnh, ảnh hưởng đến sát thương vật lý
	public int baseDexterity;      // Khéo léo, ảnh hưởng đến tốc độ tấn công, độ chính xác và né tránh
	public int baseVitality;       // Sinh lực, thường ảnh hưởng đến HP và khả năng hồi phục
	public int baseIntelligence;   // Trí tuệ, ảnh hưởng đến sát thương phép, lượng MP hoặc kỹ năng đặc biệt
	
	[Header("Chỉ số cơ bản")]
	public int baseHealth;         // Máu cơ bản (HP), lượng máu ban đầu của nhân vật
	public int baseMana;           // Mana cơ bản (MP), năng lượng dùng cho kỹ năng phép hoặc skill đặc biệt
	public int baseDefense;        // Phòng thủ cơ bản, giảm sát thương nhận vào từ đòn tấn công vật lý hoặc phép
	public float baseAttackSpeed;  // Tốc độ đánh cơ bản, ảnh hưởng đến tốc độ thực hiện đòn tấn công (đòn càng nhanh, DPS càng cao)
	
	[Header("chi so damage")]
	public float damage;             // Sát thương gây ra
	public float fireRate;           // Tốc độ bắn / tấn công
	public float critChance;        // Tỉ lệ chí mạng (%)
	public float critMultiplier;    // Sát thương nhân chí mạng (%)

	[Header("chi so nang luong")]
	public float dodgeChance;        // % né đòn
	public float energy;             // Năng lượng
	public float energyRegen;        // Tốc độ hồi năng lượng

	public float magnetRange;        // Tầm hút vật phẩm
	public float hpRegen;            // Hồi máu theo thời gian
	public float cooldownReduction;  // Giảm thời gian hồi chiêu (%)
	//
	public int bonusATK;
	public int bonusDEF;

	// Bonus Stats
	public float critRate = 10;     // % Tỉ lệ chí mạng
	public int critDamage = 150;    // % Sát thương chí mạng
	public int armorPen = 0;        // % Xuyên giáp
	public int lifesteal = 0;       // % Hút máu

	//Kháng nguyên tố & nội công
	public int resistFire;         // Kháng lửa
	public int resistIce;          // Kháng băng
	public int resistPoison;       // Kháng độc
	public int innerPower;         // Nội công (năng lực đặc biệt)

	//Skill
	public string skillName;       // Tên kỹ năng
	public int mpCost;             // Mana tiêu tốn
	public float cooldown;         // Thời gian hồi chiêu

	//
	public int strength;           // Sức mạnh
	public int dexterity;          // Khéo léo
	public int vitality;           // Thể lực
	public int intelligence;       // Trí thông minh

	// Base stats
	public float baseHP = 100f;             // Máu cơ bản ban đầu (HP)
	public float baseAttack = 10f;          // Sát thương cơ bản mỗi phát
	public float baseFireRate = 1f;         // Tốc độ bắn cơ bản (số phát/giây)
	public float baseMoveSpeed = 5f;        // Tốc độ di chuyển cơ bản
	public float baseCritRate = 5f;         // Tỷ lệ chí mạng cơ bản (%)
	public float baseCritDmg = 150f;        // Sát thương chí mạng cơ bản (%) — thường = 150%

	// Final stats sau khi cộng
	public float finalHP;                   // Máu sau khi cộng thêm từ trang bị, buff
	public float finalAttack;               // Sát thương cuối cùng
	public float finalFireRate;             // Tốc độ bắn cuối cùng
	public float finalMoveSpeed;            // Tốc độ di chuyển cuối cùng
	public float finalCritRate;             // Tỷ lệ chí mạng cuối cùng
	public float finalCritDmg;              // Sát thương chí mạng cuối cùng

	public float equipmentHPBonus;          // Lượng máu cộng thêm từ trang bị
	public float equipmentAttackBonus;      // Sát thương cộng thêm từ trang bị
	public float buffCritRateBonus;         // Tỷ lệ chí mạng cộng thêm từ buff (thời gian ngắn hoặc kỹ năng)

	public float attack = 10;               // Sát thương hiện tại (có thể thay đổi trong trận)
	public float attackSpeed = 1.0f;        // Tốc độ bắn hiện tại (có thể thay đổi tạm thời)
	public float moveSpeed = 5f;            // Tốc độ di chuyển hiện tại (sau khi tính buff, slow, v.v.)
	public float shield = 50;               // Lượng khiên hiện tại (dùng để hấp thụ sát thương trước khi trừ máu)

	public int baseExp;              // EXP cơ bản nhận được
	public int baseGold;             // Vàng cơ bản nhận được
	public int expMultiplier;        // Hệ số nhân EXP
	public int goldMultiplier;       // Hệ số nhân vàn
	
	public int HP;          // HP hiện tại
    public int ATK;         // ATK hiện tại
    public float DEF;       // DEF hiện tại
    public float SPD;       // SPD hiện tại
    public int EXPToLevelUp; // EXP cần để lên cấp (giống expToNextLevel nhưng kiểu `int`)
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
	
	public void AddBonusStats(int hp, int atk, int def, float speed)
    {
        this.hp += hp;
        this.atk += atk;
        this.def += def;
        this.speed += speed;
    }
}
