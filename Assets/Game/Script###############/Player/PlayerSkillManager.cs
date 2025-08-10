using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
	public string skillName;
	public Sprite icon;
	public float cooldown;
	protected float currentCooldown;

	public virtual void Activate()
	{
		Debug.Log("Skill " + skillName + " activated!");
		currentCooldown = cooldown;
	}

	public virtual void UpdateSkill()
	{
		if (currentCooldown > 0)
		{
			currentCooldown -= Time.deltaTime;
		}
	}

	public bool IsReady()
	{
		return currentCooldown <= 0;
	}
}

public class PlayerSkillManager : MonoBehaviour {

	public SkillBase[] skills;

	void Update() {
		foreach (SkillBase skill in skills) {
			if (skill != null) skill.UpdateSkill();
		}
	}

	public void ActivateSkill(int index) {
		if (index >= 0 && index < skills.Length && skills[index] != null)
			skills[index].Activate();
	}
}
