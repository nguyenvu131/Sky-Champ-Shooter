using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillRandom : MonoBehaviour
{
	public List<BaseMonsterSkill> skillList = new List<BaseMonsterSkill>();
	public float chooseInterval = 3f;
	private float timer;

	void Start()
	{
		timer = chooseInterval;
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			TryUseRandomSkill();
			timer = chooseInterval;
		}
	}

	void TryUseRandomSkill()
	{
		List<BaseMonsterSkill> readySkills = new List<BaseMonsterSkill>();

		foreach (var skill in skillList)
		{
			if (skill != null && skill.IsReady())
				readySkills.Add(skill);
		}

		if (readySkills.Count > 0)
		{
			int index = Random.Range(0, readySkills.Count);
			readySkills[index].Use();
		}
	}
}
