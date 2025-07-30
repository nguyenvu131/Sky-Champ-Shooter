using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillManager : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform[] firePoints;
	public float fireRate = 2f;
	private float cooldown;

	void Update()
	{
		cooldown -= Time.deltaTime;
		if (cooldown <= 0f)
		{
			FireSpread(); // Gọi skill
			cooldown = fireRate;
		}
	}

	void FireSpread()
	{
		foreach (Transform point in firePoints)
		{
			Instantiate(bulletPrefab, point.position, point.rotation);
		}
	}
}
