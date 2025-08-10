using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBullet : MonoBehaviour {

	private Transform target;
	public float speed = 10f;
	private int damage;

	public void Init(Transform target, int dmg)
	{
		this.target = target;
		this.damage = dmg;
	}

	void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.position) < 0.1f)
		{
			target.GetComponent<Monster>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
