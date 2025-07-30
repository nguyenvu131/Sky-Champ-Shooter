using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	public static SkillManager Instance; // Thêm dòng này

	public List<SkillInstance> skills = new List<SkillInstance>();

	public int skillPoints = 3;

	public void LearnSkill(SkillData data)
	{
		if (!HasSkill(data))
		{
			SkillInstance newSkill = new SkillInstance { data = data, currentLevel = 1 };
			skills.Add(newSkill);
		}
	}

	public bool HasSkill(SkillData data)
	{
		for (int i = 0; i < skills.Count; i++)
		{
			if (skills[i].data == data)
			{
				return true;
			}
		}
		return false;
	}

	public bool UpgradeSkill(SkillInstance skill)
	{
		if (skillPoints > 0 && skill.CanUpgrade())
		{
			skillPoints--;
			skill.Upgrade();
			return true;
		}
		return false;
	}
}
