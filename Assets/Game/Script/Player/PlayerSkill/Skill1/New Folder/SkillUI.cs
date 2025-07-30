using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

	public SkillManager skillManager;
	public Text skillName;
	public Text skillLevel;
	public Text skillDamage;
	public Button upgradeButton;

	private SkillInstance currentSkill;

	public void ShowSkill(SkillInstance skill)
	{
		currentSkill = skill;
		skillName.text = skill.data.skillName;
		skillLevel.text = "Cấp: " + skill.currentLevel;
		skillDamage.text = "Sát thương: " + skill.GetDamage();

		upgradeButton.interactable = skillManager.skillPoints > 0 && skill.CanUpgrade();
	}

	public void OnUpgradeSkill()
	{
		if (skillManager.UpgradeSkill(currentSkill))
			ShowSkill(currentSkill); // Refresh
	}
}
