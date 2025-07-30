using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public PlayerStats stats;

//	public int maxHP = 10000;
//	private int currentHP;

	public Image hpBarFill; // (tùy chọn) Thanh máu UI

	void Start()
	{
//		stats.currentHP = stats.maxHP;

		UpdateUI();
	}

	public void TakeDamage(int damage)
	{
		stats.currentHP -= damage;
		if (stats.currentHP <= 0)
		{
			stats.currentHP = 0;
			Die();
		}

		UpdateUI();
	}

	public void Heal(int amount)
	{
		stats.currentHP += amount;
		if (stats.currentHP > stats.maxHP)
			stats.currentHP = stats.maxHP;

		UpdateUI();
	}

	void UpdateUI()
	{
		if (hpBarFill != null)
		{
			hpBarFill.fillAmount = (float)stats.currentHP / stats.maxHP;
		}
	}

	void Die()
	{
		Debug.Log("Player chết!");
		// TODO: hiệu ứng nổ / GameOver / respawn / load scene...
		gameObject.SetActive(false);
	}
}
