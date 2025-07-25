using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooter : MonsterController {

	public GameObject bulletPrefab;
	public Transform shootPoint;
	public float fireRate = 1.5f;
	private float fireTimer;
	public WeaponTypeMonster weaponType = WeaponTypeMonster.Normal;
	public Transform firePoint; 
	public float bulletSpeed = 0.5f;
	
	public float shootInterval = 2f;
	public float lastShoot;
	public MonsterStats stats;

	void Update()
	{
		fireTimer += Time.deltaTime;
		if (fireTimer >= fireRate)
		{
			Shoot();
			fireTimer = 0f;
			//lastShoot = Time.time;
		}
	}

	void Shoot()
	{
		GameObject bulletmonster = BulletPoolMonster.Instance.GetBullet(weaponType);
		if (bulletmonster == null) return;
		bulletmonster.transform.position = firePoint.position;
		bulletmonster.transform.rotation = Quaternion.identity;
		bulletmonster.SetActive(true);
		bulletmonster.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
	}
	
	public static float CalculateDamage(MonsterStats attacker, PlayerStats defender)
	{
		// 1. Cơ bản
		float baseDamage = attacker.attack;

		// 2. Chí mạng
		bool isCrit = Random.Range(0f, 100f) < attacker.finalCritRate;
		if (isCrit)
		{
			baseDamage *= attacker.finalCritDmg / 100f;
		}

		// 3. Trừ giáp hoặc kháng vật lý
		float reduced = baseDamage - defender.def;
		float final = Mathf.Max(1f, reduced); // không thể < 1

		// 4. Có thể mở rộng thêm: damage element, shield, absorb
		return final;
	}
	
	void OnEnable()
	{
		stats = GetComponent<MonsterStats>();
		lastShoot = Time.time + Random.Range(0f, 1f); // delay ngẫu nhiên ban đầu
	}
}
