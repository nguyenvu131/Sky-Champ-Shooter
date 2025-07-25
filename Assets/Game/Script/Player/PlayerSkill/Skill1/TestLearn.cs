using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLearn : MonoBehaviour {

	public SkillManager skillManager;
	public SkillData firePunch;

	void Start()
	{
		skillManager.LearnSkill(firePunch);
	}
}
