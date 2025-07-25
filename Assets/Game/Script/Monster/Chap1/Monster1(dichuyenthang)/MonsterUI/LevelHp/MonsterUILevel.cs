using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUILevel : MonoBehaviour {

	public Text nameText;
	public Text levelText;
	public Image hpBarFill;

	private Transform target;
	private MonsterStats monsterStats;
	private Camera cam;

	public Vector3 offset = new Vector3(0, 2.0f, 0);

	public void Setup(Transform target, MonsterStats stats)
	{
		this.target = target;
		this.monsterStats = stats;
		cam = Camera.main;

		nameText.text = stats.monsterName;
		levelText.text = "Lv " + stats.level.ToString();
	}

	void Update()
	{
		if (target == null || monsterStats == null || monsterStats.isDead)
		{
			gameObject.SetActive(false);
			return;
		}

		transform.position = target.position + offset;
		transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
			cam.transform.rotation * Vector3.up);

		float hpPercent = monsterStats.currentHP / (float)monsterStats.maxHP;
		hpBarFill.fillAmount = hpPercent;
	}
}
