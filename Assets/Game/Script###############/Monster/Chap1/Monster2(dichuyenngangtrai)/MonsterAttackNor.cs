using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackNor : MonoBehaviour {

	public float attackRange = 5f;
	public float attackCooldown = 2f;

	private float lastAttackTime = 0f;
	private GameObject player;
	private MonsterStats stats;
	private MonsterData data;

	void Start()
	{
//		stats = GetComponent<MonsterStats>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (!player) return;

		float dist = Vector3.Distance(transform.position, player.transform.position);
		if (dist <= attackRange && Time.time > lastAttackTime + attackCooldown)
		{
			AttackPlayer();
			lastAttackTime = Time.time;
		}
	}

	void AttackPlayer()
	{
		// float dmg = stats.CalculateDamage();
		// player.GetComponent<PlayerStats>().TakeDamage(dmg);
		stats = GetComponent<MonsterStats>();
		float dmg = stats.atk;

		PlayerStats ps = player.GetComponent<PlayerStats>();
		if (ps != null)
		{
			ps.TakeDamage(dmg);
			Debug.Log(name + " tấn công player gây " + dmg + " sát thương");
		}
	}
}
