using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//- MonsterStats.cs        // Thông số quái
//- MonsterAI.cs           // Hành vi AI cơ bản
//- MonsterShoot.cs        // Xử lý bắn
//- MonsterMovement.cs     // Di chuyển
//- MonsterSpawner.cs      // Sinh quái
//- MonsterDrop.cs         // Rớt vật phẩm
//- BossPhaseAI.cs         // AI riêng cho boss
//- ObjectPool.cs          // Tái sử dụng prefab

[System.Serializable]
public class MonsterStats     
{
	public static MonsterStats Instance;
	// Chi so nhan vat
	public float shootRate;
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
	//
	public int level = 1;
    public float hp = 100f;
    public float damage = 10f;
    public float moveSpeed = 0.5f;
    public float attackSpeed = 0.5f;
    public float dropRate = 0.3f;
    public int exp = 15;
    public int score = 100;
	//
	public int monsterID;
	public string monsterName;
	public int maxlevel = 999999;
	public float currentHP = 100f;
	public float speed = 0.5f;
	//
	public Sprite monsterIcon; // Kéo icon monster trong Inspector
	//
	public float baseDamage;
	public float finalHP;
	public float finalDamage;
	public float finalAttack;
	public float finalCritRate;
	public float finalCritDmg;
	//
	public bool isElite;
	public bool isBoss;
	//
	public float baseHP = 100f;
	public float baseATK = 10f;
	public int baseDEF = 0;
	public float baseSPD = 2.0f;
	public int baseEXP = 5;
	public int baseGold = 3;
	public float baseAttack = 10f;
	public float baseMoveSpeed = 3f;
	public float baseDefense = 0f;
	public int baseExpReward = 20;
	//
	public float maxHP;
	public float attack;
	public float defense;
	public int expReward;
	//
	public float baseCritRate = 0f;
	public float baseCritDmg = 150f;
	public float attackCooldown = 2f;
	//
	public bool isDead = false;
	public GameObject uiPrefab;
	public MonsterUI monsterUI;
	//Exp Drop
	public int expDrop = 50; // 
	public int difficultyMultiplier;
	//
	public float critRate;
	public float critDmg;
	public bool isCrit;
	//Hien Bar Hp 
	public GameObject uiPrefabLv;
	public MonsterUILv monsterUILv;
	
    [Header("Crit Settings")]
    public float critChance = 0.1f;
    public float critMultiplier = 2f;

    [Header("Hiệu ứng")]
    public string hitEffectName = "HitEffect";
    public string popupType = "damage";
	
	[Header("Gay damage")]
    public MonsterType monsterType;
	
	[Header("Roi do")]
    private MonsterDrop dropSystem;

	/////////////////////////////////////////////////////////////////////////////////
	// 1. Cấp quái dựa vào wave
    public int GetMonsterLevel(int wave)
    {
        return Mathf.Clamp(wave, 1, 999);
    }

    // 2. Cấp quái dựa vào map
    public int GetMonsterLevelByMap(int mapIndex)
    {
        int baseLevel = Mathf.Max(1, mapIndex) * 5;
        int randomOffset = Random.Range(-2, 3); // Từ -2 đến +2
        int finalLevel = baseLevel + randomOffset;

        return Mathf.Max(1, finalLevel);
    }

	public int CalculateMonsterLevel(int mapIndex, int wave, int playerLevel, float timeAlive)
	{
		int levelFromMap = mapIndex * 4;
		int levelFromWave = wave;
		int levelFromPlayer = Mathf.FloorToInt(playerLevel * 0.5f);
		int levelFromTime = Mathf.FloorToInt(timeAlive / 20f);

		int finalLevel = levelFromMap + levelFromWave + levelFromPlayer + levelFromTime;
		return Mathf.Clamp(finalLevel, 1, 999);
	}

	public void Init(int map, int wave, int playerLv, float timeAlive)
	{
		level = CalculateMonsterLevel(map, wave, playerLv, timeAlive);

		finalHP = baseHP * (1 + level * 0.2f);
		finalDamage = baseDamage * (1 + level * 0.15f);
		expDrop = Mathf.RoundToInt(baseExpReward * (1 + level * 0.1f) * difficultyMultiplier);
	}

	void ShowDamagePopup(float finalDamage, bool isCrit)
	{
		//		if (hitPopupPrefab)
		//		{
		//			GameObject go = Instantiate(hitPopupPrefab, transform.position + Vector3.up, Quaternion.identity);
		//			go.GetComponent<DamagePopup>().Show(finalDamage, isCrit);
		//		}
	}

	public void Init(int _level)
	{
		//
		level = _level;

		//
		float eliteBonus = isElite ? 1.25f : 1f;
		float bossMultiplier = isBoss ? 1.5f : 1f;

		//
		maxHP     = (baseHP + level * 20) * eliteBonus * bossMultiplier;
		attack    = (baseAttack + level * 2) * eliteBonus * bossMultiplier;
		moveSpeed = baseMoveSpeed + level * 0.02f;
		defense   = baseDefense + level * 0.5f;
		expReward = Mathf.FloorToInt((baseExpReward + level * 2) * (isElite ? 1.5f : 1f) * (isBoss ? 2f : 1f));
		//
		float bossBonus = isBoss ? 1.5f : 1f;

		//
		currentHP = (baseHP + level * 20) * eliteBonus * bossBonus;
		finalAttack = (baseAttack + level * 2) * eliteBonus * bossBonus;
		finalCritRate = baseCritRate + level * 0.2f;
		finalCritDmg = baseCritDmg + level * 1.5f;
	}

	public float CalculateDamage()
	{
		float dmg = finalAttack;
		isCrit = false;

		if (Random.Range(0f, 100f) < finalCritRate)
		{
			dmg *= finalCritDmg / 100f;
			isCrit = true;
		}

		return dmg;
	}	
		
	public void InitWave(int waveLevel)
	{
		level = waveLevel;
		float eliteBonus = isElite ? 1.3f : 1f;
		float bossBonus = isBoss ? 1.6f : 1f;

		maxHP = (baseHP + level * 20) * eliteBonus * bossBonus;
		attack = (baseAttack + level * 2) * eliteBonus * bossBonus;
		defense = baseDefense + level * 0.5f;
		moveSpeed = baseMoveSpeed + level * 0.02f;
		expReward = Mathf.FloorToInt((baseExpReward + level * 2) * eliteBonus * bossBonus);

		currentHP = maxHP;
		critRate = 5 + level * 0.2f;
		critDmg = 150 + level * 1.5f;
		
		// Gắn khi tạo từ Spawner
        // level = waveLevel;
        // maxHP += waveLevel * 10;
        // defense += waveLevel * 1;
        // expDrop += waveLevel * 2;
        // currentHP = maxHP;
	}
	
	void OnEnable()
	{
		if (uiPrefab != null && monsterUI == null)
		{
			// GameObject ui = Instantiate(uiPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
			// ui.transform.SetParent(GameObject.Find("UIWorldCanvas").transform); // Hoặc null nếu không
			// monsterUI = ui.GetComponent<MonsterUI>();
			// monsterUI.target = this.transform;
		}
	}
	
	public void TakeDamage(float baseDamage)
    {
        bool isCrit = Random.value < critChance;
        TakeDamage(baseDamage, isCrit);
    }

    public void TakeDamage(float baseDamage, bool isCrit)
    {
        // Tính sát thương thực
        float damage = baseDamage - defense;
        if (damage < 1) damage = 1;

        if (isCrit)
            damage *= critMultiplier;
        
		currentHP -= damage;
        // Gọi Popup

        // Gọi hiệu ứng trúng đạn
        if (!string.IsNullOrEmpty(hitEffectName))
        {
			// Goi hieu ung
            // EffectPoolManager.Instance.SpawnEffect(hitEffectName, transform.position, Quaternion.identity);
        }

        // Check chết
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Gọi Drop
        if (dropSystem != null)
            dropSystem.SpawnDrop();

        // Gọi EXP lên người chơi
        // PlayerEXP playerEXP = FindObjectOfType<PlayerEXP>();
        // if (playerEXP != null)
            // playerEXP.GainEXP(expDrop);

        // gameObject.SetActive(false);
    }
	
	
	void Awake()
    {
        currentHP = maxHP;
        // dropSystem = GetComponent<MonsterDrop>();
    }
	
	public void Init(MonsterData data)
    {
        monsterName = data.monsterName;
        maxHP = hp;
        currentHP = maxHP;
        // damage = baseDamage;
        // moveSpeed = moveSpeed;
        expDrop = data.expDrop;
    }
	
	
	
	public MonsterStats(int level)
    {
        this.level = level;

        baseHP = 100f;
        baseATK = 10f;
        baseDEF = 0;
        baseSPD = 2.0f;
        baseEXP = 5;
        baseGold = 3;
		
		hp = 100 * Mathf.Pow(1.2f, level - 1);
        damage = 10 + (level - 1) * 4;
        moveSpeed = 2.5f + (level - 1) * 0.15f;
        attackSpeed = Mathf.Clamp(2f - (level - 1) * 0.1f, 0.5f, 2f);
        dropRate = Mathf.Clamp(0.2f + (level - 1) * 0.02f, 0.2f, 0.5f);
        exp = Mathf.RoundToInt(5 * Mathf.Pow(1.2f, level - 1));
        score = Mathf.RoundToInt(100 * Mathf.Pow(1.2f, level - 1));
        
    }
}
