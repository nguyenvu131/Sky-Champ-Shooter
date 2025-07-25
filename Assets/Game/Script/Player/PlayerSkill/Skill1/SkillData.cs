using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType {
	Attack, Buff, Heal, Debuff, Shield, Defense, Move, Support, Ultimate
}

public enum ElementType
{
	None,
	Physical,
	Fire,
	Ice,
	Wind,
	Lightning,
	Dark,
	Holy
}

[System.Serializable]
public class SkillData {
	
	public static SkillData Instance;
	public string skillName;
	public int level;
//	public int baseDamage;
	public float atkRate; // Ví dụ: 1.5 = 150% ATK
	public int manaCost;
	public Sprite icon;
	public int maxLevel = 10;
	public int[] baseDamage;   // Damage theo từng cấp
	public int[] mpCost;       // Mana tiêu hao theo cấp
	public float[] effectChance; // % gây hiệu ứng (nếu có)

//	public string skillName;
	public SkillType skillType;
	public float cooldown;
	public float energyCost;
	public float duration;
	public float effectPower;
	public string description;

	public string skillID;
//	public string skillName;
//	public string description;
//	public Sprite icon;
	public AnimationClip animationClip;
	public GameObject effectPrefab;

	public SkillType type;
//	public Sprite icon;
	public GameObject prefabEffect;
	public float value; // damage, heal, speed, v.v.

	// Tính sát thương cuối cùng gây ra

}
