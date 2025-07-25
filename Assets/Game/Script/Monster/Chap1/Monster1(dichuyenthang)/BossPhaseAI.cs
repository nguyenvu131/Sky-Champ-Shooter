using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseAI : MonoBehaviour {

	public MonsterStats stats;
	public MonsterShooter monsterShoot;
	private int phase = 1;

	void Update()
	{
		if (phase == 1 && stats.currentHP <= stats.maxHP * 0.7f)
		{
			phase = 2;
			EnterPhase2();
		}
		else if (phase == 2 && stats.currentHP <= stats.maxHP * 0.3f)
		{
			phase = 3;
			EnterPhase3();
		}
	}

	void EnterPhase2()
	{
		GetComponent<MonsterShooter>().fireRate *= 0.7f;
	}

	void EnterPhase3()
	{
		GetComponent<MonsterShooter>().fireRate *= 0.5f;
		GetComponent<MonsterStats>().speed += 1.5f;
	}
}
