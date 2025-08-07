using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUILv : MonoBehaviour {

	public Image hpFill;
	public Text levelText;
	public Transform target;     // Monster/Player Transform
	private MonsterStats stats;  // Hoặc PlayerStats nếu là player

	void Start()
	{
		if (target != null)
			stats = target.GetComponent<MonsterStats>();  // hoặc PlayerStats
	}

	void Update()
	{
		if (target == null || stats == null) return;

		// Theo dõi target
		transform.position = target.position + Vector3.up * 1.5f;

		// Luôn quay về camera
		transform.rotation = Camera.main.transform.rotation;

		// Cập nhật UI
		hpFill.fillAmount = stats.currentHP / stats.maxHP;
		levelText.text = "Lv. " + stats.level;
	}
}
