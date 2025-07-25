using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public int maxHP = 500;
	private int currentHP;

	public GameObject healthBarUI;
	public Image fillImage;

	public delegate void OnBossDead();
	public static event OnBossDead onBossDead;

	void Start()
	{
		currentHP = maxHP;
		healthBarUI.SetActive(true);
		UpdateHealthBar();
	}

	public void TakeDamage(int damage)
	{
		currentHP -= damage;
		currentHP = Mathf.Clamp(currentHP, 0, maxHP);
		UpdateHealthBar();

		if (currentHP <= 0)
			Die();
	}

	void UpdateHealthBar()
	{
		fillImage.fillAmount = (float)currentHP / maxHP;
	}

	void Die()
	{
		healthBarUI.SetActive(false);
		onBossDead.Invoke();
		GetComponent<BossDeathHandler>().HandleDeath();
	}
}
