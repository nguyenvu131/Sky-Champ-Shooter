using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PassiveEffectType
{
	None,
	BonusCritRate,
	LifeSteal,
	AttackSpeedBoostOnLowHP,
	ShieldOnHit
}

[System.Serializable]
public class ItemDataMonster
{
	public string itemName;
	public ItemType type;
	public int attackBonus;
	public Sprite icon;
	public int rarity;

	public GameObject bulletPrefab;      // Prefab đạn tương ứng
	public GameObject hitVFXPrefab;      // VFX khi trúng mục tiêu
	public AudioClip fireSFX;            // Âm thanh bắn

	public PassiveEffectType passiveEffect;
	public float passiveValue;

	public ItemDataMonster(string name, ItemType type, int atk, Sprite icon, int rarity,
		GameObject bullet, GameObject hitVfx, AudioClip fireSound,
		PassiveEffectType effect, float value)
	{
		itemName = name;
		this.type = type;
		attackBonus = atk;
		this.icon = icon;
		this.rarity = rarity;

		bulletPrefab = bullet;
		hitVFXPrefab = hitVfx;
		fireSFX = fireSound;

		passiveEffect = effect;
		passiveValue = value;
	}
}
