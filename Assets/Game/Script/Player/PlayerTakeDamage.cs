using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTakeDamage : MonoBehaviour {

	public PlayerStats stats;

	public int level = 1;
	public float maxHP = 100f;
	public float currentHP;

	public float maxMP = 100f;
	public float currentMP;

	public float attack = 20f;
	public float defense = 5f;
	public float critChance = 0.1f;

	public float exp = 0;
	public float expToNextLevel = 100f;

	public PlayerData data;

	public UnityEvent onTakeDamage;
	public UnityEvent onDie;
	public UnityEvent onLevelUp;
	public UnityEvent onHeal;

	void Start()
	{
		stats.currentHP = stats.maxHP;
		stats.currentMP = stats.maxMP;
	}
			
	public void Heal(float amount)
	{
		currentHP = Mathf.Min(currentHP + amount, maxHP);
		onHeal.Invoke();
	}

	public void UseMP(float amount)
	{
		currentMP = Mathf.Max(currentMP - amount, 0f);
	}

	public void GainEXP(float amount)
	{
		exp += amount;
		while (exp >= expToNextLevel)
		{
			exp -= expToNextLevel;
			LevelUp();
		}
	}

	void LevelUp()
	{
		level++;
		maxHP += 20;
		attack += 5;
		defense += 2;
		maxMP += 10;
		currentHP = maxHP;
		currentMP = maxMP;
		expToNextLevel *= 1.2f;
		onLevelUp.Invoke();
	}

	public void TakeDamage(float damage)
	{
		float finalDamage = Mathf.Max(damage - defense, 1f);
		currentHP -= finalDamage;

		onTakeDamage.Invoke();

		if (currentHP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		currentHP = 0;
		if (onDie != null)
			onDie.Invoke();
		
		GetComponent<MonsterDrop>().Drop();
		// Gợi ý: Animator.SetTrigger("Die") hoặc PlayerManager.Instance.PlayerDie();
		gameObject.SetActive(false); // hoặc animation chết
	}

	public bool IsDead()
	{
		return currentHP <= 0;
	}

	public bool CanUseMP(float amount)
	{
		return currentMP >= amount;
	}
	
	public float GetAttack()
    {
        return stats.atk + (stats.level * 2);
    }
}
