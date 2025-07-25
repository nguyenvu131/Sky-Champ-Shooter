using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour 
{

	public float maxHP = 50f;
	public float currentHP;
	public float attack = 10f;
	public float defense = 2f;
	public float expReward = 10f;

	void OnEnable()
	{
		currentHP = maxHP;
	}

	public void TakeDamage(float damage)
	{
		float final = Mathf.Max(damage - defense, 1);
		currentHP -= final;

		if (currentHP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GetComponent<MonsterDrop>().Drop();
		GetComponent<MonsterDeathHandler>().HandleDeath();
		gameObject.SetActive(false);
	}
}
