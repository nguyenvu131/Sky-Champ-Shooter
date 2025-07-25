using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletRadial : MonoBehaviour {

	private Vector3 velocity;
	private float damage;
	private bool isCrit;

	public void Init(MonsterStats attacker, Vector3 velocity)
	{
		this.velocity = velocity;

		damage = attacker.attack;
		isCrit = Random.Range(0f, 100f) < attacker.finalCritRate;
		if (isCrit)
			damage *= attacker.finalCritDmg / 100f;
	}

	void Update()
	{
		transform.position += velocity * Time.deltaTime;

		if (transform.position.magnitude > 15f)
		{
			ObjectPooler.Instance.ReturnToPool("MonsterBullet", gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerStats player = other.GetComponent<PlayerStats>();
			float finalDmg = Mathf.Max(1, damage - player.def);
			player.TakeDamage(finalDmg);

			PopupTextPoolManager.Instance.SpawnPopup(isCrit ? "crit" : "damage", transform.position, finalDmg.ToString("F0"));

			ObjectPooler.Instance.ReturnToPool("MonsterBullet", gameObject);
		}
	}
}
