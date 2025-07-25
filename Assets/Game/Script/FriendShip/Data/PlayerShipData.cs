using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipData", menuName = "PlayerShipData/PlayerShipData")]
[System.Serializable]
public class PlayerShipData : ScriptableObject 
{
	public string shipName;
	public int level;
	public float hp;
	public float shield;
	public float energy;
	public float moveSpeed;
	public float fireRate;
	public float damage;
	public float critRate;
	public float critDamage;
	public float bulletSpeed;
	public float evasion;
	public float lifeSteal;

	public WeaponData equippedWeapon;
	public List<SkillData> skills;
}
