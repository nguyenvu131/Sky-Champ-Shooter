using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private GameObject target;
	private MonsterAttack source;

	public float speed = 10f;

	public void Init(GameObject t, MonsterAttack attacker)
	{
		target = t;
		source = attacker;
	}

	void Update()
	{
		if (target == null) Destroy(gameObject);

		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
		{
			source.Attack(target);
			Destroy(gameObject);
		}
	}
}
