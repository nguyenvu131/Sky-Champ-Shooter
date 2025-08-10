using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FriendData 
{
	public string friendName;
	public Sprite icon;

	public float maxHP = 100;
	public float damage = 10;
	public float fireRate = 1f;
	public float followDistance = 2f;

	public GameObject bulletPrefab;
	public float bulletSpeed = 8f;

	public float skillCooldown = 10f;
}
