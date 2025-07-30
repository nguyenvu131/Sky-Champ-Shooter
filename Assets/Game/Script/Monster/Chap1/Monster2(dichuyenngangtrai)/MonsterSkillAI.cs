using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillAI : MonoBehaviour {

	public GameObject skillPrefab;
	public float skillCooldown = 5f;
	private float lastSkillTime;
	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (Time.time > lastSkillTime + skillCooldown && Vector3.Distance(transform.position, player.transform.position) < 7f)
		{
			UseSkill();
			lastSkillTime = Time.time;
		}
	}

	void UseSkill()
	{
//		GameObject skill = Instantiate(skillPrefab, transform.position, Quaternion.identity);
//		skill.GetComponent<MonsterSkillNor>().Initialize(player.transform);
	}
}
