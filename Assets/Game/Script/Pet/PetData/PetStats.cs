using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetSkillBase : ScriptableObject {
    public string skillName;
    public float cooldown;
    public abstract void Activate(GameObject pet, GameObject player);
}

[System.Serializable]
public class PetStats : MonoBehaviour 
{

	public PlayerStats stats;
	
	public int level = 1;
	public int maxHP = 100;
	public float currentHP;
	public float attackPower = 10f;
	public float attackRate = 1f;

	public Transform firePoint;
	//
	public string petName;
	public float atk = 10f;
	public float fireRate = 1f;
	public float range = 5f;
	public float moveSpeed = 5f;
	
    public Sprite icon;
    public float attack;
    public GameObject bulletPrefab;
    public PetSkillBase skill;
	
	public string petID;
    public int exp;
    public int rarity; // 1-5 sao
    public int evolveStage; // 0 = chưa tiến hoá, 1,2,3...

    public float baseHP;
    public float baseAttack;
    public float baseAttackSpeed;
    public float baseMoveSpeed;
    public float currentAttack;
    public float currentAttackSpeed;
    public float currentMoveSpeed;
    public float growthHP;
    public float growthAttack;
    public float growthAttackSpeed;
    public float growthMoveSpeed;
	
    public int currentExp = 0;
    public int expToNext = 0;
    public int damage;
    public float attackSpeed;
    public int hp;
    public float skillCooldown;
	
	void Awake()
	{
		currentHP = maxHP;
	}

	public void LevelUp()
	{
		level++;
		attackPower += 5f;
		maxHP += 20;
		currentHP = maxHP;
	}
	
	public void CalculateStats() {
        currentHP = baseHP + growthHP * (level - 1);
        currentAttack = baseAttack + growthAttack * (level - 1);
        currentAttackSpeed = baseAttackSpeed + growthAttackSpeed * (level - 1);
        currentMoveSpeed = baseMoveSpeed + growthMoveSpeed * (level - 1);
    }

	public void GainExp(int amount) {
        exp += amount;
        while (exp >= GetExpToNextLevel()) {
            exp -= GetExpToNextLevel();
            level++;
            CalculateStats();
        }
    }

    private int GetExpToNextLevel() {
        return 100 + level * 20; // ví dụ: cấp 1 cần 120 exp, cấp 2 cần 140,...
    }
	
}
