using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {

	public MonsterStats stats;

	public Transform firePoint;
	public GameObject bulletPrefab;
	public float shootCooldown = 2f;
	private float lastShootTime;

	public Transform target;
	public float chaseDistance = 10f;

	void Start()
	{
		stats = GetComponent<MonsterStats>();
	} 

	void Update()
	{
		Move();
		if (Time.time > lastShootTime + shootCooldown)
		{
			Attack();
			lastShootTime = Time.time;
		}
			
			
	}

	void Move()
	{
		transform.Translate(Vector3.down * stats.moveSpeed * Time.deltaTime);
	}

	void Attack()
	{
		GameObject bullet = ObjectPooler.Instance.Spawn("MonsterBullet", firePoint.position, Quaternion.identity);
		bullet.GetComponent<MonsterBullet>().Init(stats.attack);
	}
}
