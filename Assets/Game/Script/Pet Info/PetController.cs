using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour {

	public Transform target; // Player
	public PetStatsSO stats;
	private float fireCooldown;

	void Update()
	{
		FollowTarget();
		TryShoot();
	}

	void FollowTarget()
	{
		if (target == null) return;

		Vector3 followPos = target.position + Vector3.left * stats.followDistance;
		transform.position = Vector3.Lerp(transform.position, followPos, stats.moveSpeed * Time.deltaTime);
	}

	void TryShoot()
	{
		fireCooldown -= Time.deltaTime;
		if (fireCooldown <= 0f)
		{
			GameObject enemy = FindNearestEnemy();
			if (enemy != null)
			{
				FireAt(enemy.transform);
				fireCooldown = 1f / stats.fireRate;
			}
		}
	}

	void FireAt(Transform enemy)
	{
		GameObject bullet = Instantiate(stats.bulletPrefab, transform.position, Quaternion.identity);
		bullet.GetComponent<PetBullet>().Init(enemy, stats.damage);
	}

	GameObject FindNearestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float minDist = Mathf.Infinity;
		foreach (var e in enemies)
		{
			float dist = Vector3.Distance(transform.position, e.transform.position);
			if (dist < minDist)
			{
				minDist = dist;
				closest = e;
			}
		}
		return closest;
	}
}
