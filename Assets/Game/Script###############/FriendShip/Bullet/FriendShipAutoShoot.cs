using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShipAutoShoot : MonoBehaviour {

	public float fireRate = 1f;
	public float fireRange = 5f;
	public Transform firePoint;

	private float nextFireTime = 0f;

	void Update()
	{
		if (Time.time >= nextFireTime)
		{
			GameObject enemy = FindNearestEnemy();
			if (enemy != null)
			{
				ShootAt(enemy.transform.position);
				nextFireTime = Time.time + 1f / fireRate;
			}
		}
	}

	GameObject FindNearestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float minDist = Mathf.Infinity;
		GameObject nearest = null;

		foreach (var e in enemies)
		{
			float dist = Vector3.Distance(transform.position, e.transform.position);
			if (dist < minDist && dist <= fireRange)
			{
				minDist = dist;
				nearest = e;
			}
		}

		return nearest;
	}

	void ShootAt(Vector3 targetPos)
	{
		GameObject bullet = BulletPoolShip.Instance.GetBullet();
		bullet.transform.position = firePoint.position;

		Vector3 dir = (targetPos - firePoint.position).normalized;
		bullet.transform.up = dir; // hướng đầu đạn

		// Có thể truyền damage hoặc mục tiêu vào nếu muốn
	}
}
