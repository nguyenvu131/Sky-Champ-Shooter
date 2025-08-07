using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthUI : MonoBehaviour {

	public Image hpBar;
	private MonsterStats stats;

	void Start()
	{
		stats = GetComponentInParent<MonsterStats>();

		if (hpBar == null)
			Debug.LogWarning("HP Bar is not assigned!", gameObject);

		if (stats == null)
			Debug.LogWarning("MonsterStats not found in parent!", gameObject);
	}

	void Update()
	{
		if (hpBar != null && stats != null && stats.maxHP > 0)
		{
			hpBar.fillAmount = (float)stats.currentHP / (float)stats.maxHP;
		}
	}
}
