using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfoUI : MonoBehaviour {

	public Text nameText;
	public Text levelText;
	public Image hpBarFill;
	public Image icon;

	private MonsterStats stats;

	void Start()
	{
		stats = GetComponentInParent<MonsterStats>();
		UpdateInfo();
	}

	void Update()
	{
		if (stats == null) return;

		float hpPercent = stats.currentHP / stats.maxHP;
		hpBarFill.fillAmount = hpPercent;

		// Ẩn nếu chết
		if (stats.currentHP <= 0)
		{
			gameObject.SetActive(false);
		}
	}

	public void UpdateInfo()
	{
		if (stats == null) return;

		nameText.text = stats.monsterName;
		levelText.text = "Lv " + stats.level.ToString();
		if (icon != null && stats.monsterIcon != null)
			icon.sprite = stats.monsterIcon;
	}
}
