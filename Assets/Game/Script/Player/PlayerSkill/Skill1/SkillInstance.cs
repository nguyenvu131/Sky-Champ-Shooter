using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillInstance
{
	public SkillData data;
	public int currentLevel = 1;

	public int GetDamage()
	{
		return data.baseDamage[currentLevel - 1];
	}

	public int GetMPCost()
	{
		return data.mpCost[currentLevel - 1];
	}

	public float GetEffectChance()
	{
		return data.effectChance[currentLevel - 1];
	}

	public bool CanUpgrade()
	{
		return currentLevel < data.maxLevel;
	}

	public void Upgrade()
	{
		currentLevel++;
	}
}
