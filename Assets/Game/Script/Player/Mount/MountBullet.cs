using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountBullet : MonoBehaviour {

	public float speed = 10f;
	private float damage;

	public void Init(float dmg)
	{
		damage = dmg;
	}

	void Update()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<CombatStats>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
