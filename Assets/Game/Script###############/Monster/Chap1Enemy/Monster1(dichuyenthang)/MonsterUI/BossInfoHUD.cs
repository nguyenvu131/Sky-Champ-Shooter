using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Cách dùng:
// Khi bắt đầu boss fight:
//bossHUD.SetBoss(currentBoss.GetComponent<MonsterStats>());

public class BossInfoHUD : MonoBehaviour {

	public Text nameText;
	public Image hpBarFill;
	public Image icon;

	private MonsterStats bossStats;

	public void SetBoss(MonsterStats stats)
	{
		bossStats = stats;
		nameText.text = stats.monsterName;
		icon.sprite = stats.monsterIcon;
	}

	void Update()
	{
		if (bossStats == null) return;

		hpBarFill.fillAmount = bossStats.currentHP / bossStats.maxHP;

		if (bossStats.currentHP <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
