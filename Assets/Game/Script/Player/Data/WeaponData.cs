using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType{Gold, Gem, Crystal}

public enum WeaponType {
	Laser, Missile, Plasma, Spread, Beam, Drone
}

[System.Serializable]
public class WeaponData 
{
	public string weaponID;
	public string weaponName;
	public Sprite icon;
	public GameObject bulletPrefab;

	public int price;
	public CurrencyType currency;

	public float damage;
	public float fireRate;
	public float bulletSpeed;
	public float critChance;
	public string description;

	public bool unlockedByDefault;

	public WeaponType weaponType;
	public float cooldown;
	public int ammoCount;
	public float explosionRadius;
	public int upgradeLevel;
	
    public float baseDamage;
    public int bulletCount; // Số viên bắn ra mỗi phát
    
}
