using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillEffectType
{
    Dash,
    AreaExplosion,
    Shield,
    Poison,
    Slow,
    Summon
}

[CreateAssetMenu(fileName = "MonsterSkillData", menuName = "Monster/Create New Skill")]
public class MonsterSkillData : ScriptableObject
{
    public string skillID;
    public string skillName;
    public Sprite icon;
    public float cooldown = 5f;
    public SkillEffectType effectType;
    public GameObject skillPrefab;
    public float duration;
    public float effectValue;
	
	// public string skillName;
	public SkillType skillType;
	public float powerMultiplier = 1.0f;  // Nhân với monsterATK
	// public float cooldown = 5f;
	public float range = 10f;

	public float effectDuration = 3f;   // DOT/Debuff
	public float tickInterval = 1f;     // nếu DOT
	public GameObject effectPrefab;     // Particle hoặc hiệu ứng
}
