using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MountSkillType
{
	None,
	Active,
	Passive,
	AutoTimed
}

[CreateAssetMenu(menuName = "Game/Mount")]
public class MountData : ScriptableObject
{
	public string mountID;
	public string displayName;
	public Sprite icon;
	public GameObject mountPrefab;
	public float attackDamage;
	public float fireRate;
	public GameObject bulletPrefab;
	public AudioClip fireSFX;

	[Header("Skill")]
	public MountSkillType skillType;
	public GameObject skillEffectPrefab;
	public float skillCooldown = 5f;
	public float skillPower = 1f;
}
