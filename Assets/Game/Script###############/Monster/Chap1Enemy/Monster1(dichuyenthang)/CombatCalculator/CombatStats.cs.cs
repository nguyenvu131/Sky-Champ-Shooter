using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CombatStats : MonoBehaviour {

	public float atk = 100;
	public float def = 50;
	public float critRate = 0.1f;
	public float critDmg = 2.0f; // x2 crit damage

	public float hp = 1000;
	public float maxHp = 1000;

	public bool isPlayer = false;
	public GameObject deathEffect;


	public void TakeDamage(float amount)
	{
		hp -= amount;
		if (hp <= 0)
		{
			hp = 0;
//			GetComponent<MonsterStats>().Die(); // hoặc PlayerDie
			Die();
		}
	}

	void Die()
	{
		if (deathEffect)
			Instantiate(deathEffect, transform.position, Quaternion.identity);

		if (isPlayer)
		{
//			GameManager.Instance.OnPlayerDie();
		}
		else
		{
			MonsterDeathHandler monster = GetComponent<MonsterDeathHandler>();
			if (monster != null) monster.HandleDeath();
		}

		Destroy(gameObject); // Hoặc dùng Object Pooling nếu muốn
	}
}
