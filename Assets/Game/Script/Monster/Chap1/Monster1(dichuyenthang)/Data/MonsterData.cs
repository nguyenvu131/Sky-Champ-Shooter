using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle,
    Patrol,
    Attack,
    Evade,
    Retreat,
    Die
}

public enum MonsterType
{
    Normal,
    Elite,
    Boss,
    Formation
}

public enum BulletType
{
    Normal,
    Homing,
    Wave,
    Spread,
    Laser,
    Exploding,
    Poison
}

public enum AIType
{
    Simple,         // bay thẳng
    FollowPlayer,   // đuổi theo player
    Pattern,        // theo pattern zigzag, sine, etc.
    Formation,      // theo đội hình
    SkillBased      // dùng kỹ năng thông minh
}

[CreateAssetMenu(fileName = "MonsterData", menuName = "Monster/Create New Monster Data")]
public class MonsterData : ScriptableObject
{
	//
	public string monsterID;
    public string monsterName;
    public Sprite icon;
	
    public int maxHealth;
    public float moveSpeed;
    public Sprite sprite;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
	
    [Header("Base Stats")]
    public float baseHP;
    public float baseMoveSpeed;
    public float baseAttackSpeed;
    public float baseDamage;

    [Header("Level Scaling")]
    public AnimationCurve hpCurve;
    public AnimationCurve damageCurve;
    public AnimationCurve moveSpeedCurve;

    [Header("Attack")]
    public BulletType bulletType;
    public float fireRate;
    public bool isHoming;
    public bool isBurst;
    public int burstCount;
    public float burstDelay;

    [Header("Monster Type")]
    public MonsterType monsterType; // Normal, Elite, Boss, Formation

    [Header("AI Behavior")]
    public AIType aiType; // Simple, FollowPlayer, Pattern, Formation, SkillBased

    [Header("Skills")]
    public SkillData[] skills;

    [Header("Rewards")]
    public int expDrop;
    public int coinDrop;
	

	//
	public float baseAttack;
	public float baseDefense;
	public int baseExpReward;
	public float baseCritRate;
	public float baseCritDmg;
	
}
