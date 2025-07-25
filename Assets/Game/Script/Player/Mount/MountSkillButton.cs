using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountSkillButton : MonoBehaviour {

	public MountControllerMonster mountMonster;
	private float cooldown;
	private float timer;
	public float skillCooldown;

	public Image cooldownFill;

	void Start()
	{
		mountMonster = FindObjectOfType<MountControllerMonster>();
		cooldown = skillCooldown;
		timer = cooldown;
	}

	void Update()
	{
		if (mountMonster == null) return;

		timer += Time.deltaTime;
		cooldownFill.fillAmount = Mathf.Clamp01(timer / cooldown);
	}

	public void OnClickUseSkill()
	{
		if (timer >= cooldown)
		{
			timer = 0;
			mountMonster.ActivateSkill();
		}
	}
}
