using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Goi ham tan cong
//monsterAttack.Attack(player.gameObject);

public class MonsterAttack : MonoBehaviour {

	public float skillMultiplier = 1.2f; // skill damage hệ số
	public Transform firePoint;
	public GameObject projectilePrefab;

	public void Attack(GameObject target)
	{
		CombatStats attacker = GetComponent<CombatStats>();
		CombatStats receiver = target.GetComponent<CombatStats>();

		if (attacker == null || receiver == null) return;

	}

	public void FireProjectile(GameObject target)
	{
		GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
		proj.GetComponent<Projectile>().Init(target, this);
	}
}
