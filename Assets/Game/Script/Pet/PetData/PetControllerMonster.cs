using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetControllerMonster : MonoBehaviour {

	private PetStats stats;
	private float atkTimer = 0f;

	void Start()
	{
		stats = GetComponent<PetStats>();
	}

	void Update()
	{
		atkTimer += Time.deltaTime;

		if (atkTimer >= stats.attackRate)
		{
			Transform target = FindNearestEnemy();
			if (target != null)
			{
				FireAt(target);
				atkTimer = 0f;
			}
		}
	}

	void FireAt(Transform enemy)
	{
		GameObject bullet = Instantiate(stats.bulletPrefab, stats.firePoint.position, Quaternion.identity);
		Vector3 dir = (enemy.position - transform.position).normalized;
		bullet.GetComponent<Rigidbody2D>().velocity = dir * 10f;
	}

	Transform FindNearestEnemy()
	{
		float minDist = Mathf.Infinity;
		Transform nearest = null;
		foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			float dist = Vector3.Distance(transform.position, e.transform.position);
			if (dist < minDist)
			{
				minDist = dist;
				nearest = e.transform;
			}
		}
		return nearest;
	}
}
