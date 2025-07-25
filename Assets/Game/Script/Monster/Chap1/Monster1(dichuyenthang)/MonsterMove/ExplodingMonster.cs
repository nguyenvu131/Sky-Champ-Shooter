using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Exploding Monster – Tự sát khi tiếp cận Player
public class ExplodingMonster : MonoBehaviour {

	public float explodeRange = 1.5f;
	public float explodeDamage = 100f;
	private Transform player;
	private MonsterStats stats;

	void OnEnable()
	{
		stats = GetComponent<MonsterStats>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		transform.position += Vector3.down * stats.moveSpeed * Time.deltaTime;

		if (Vector3.Distance(transform.position, player.position) < explodeRange)
		{
			Explode();
		}
	}

	void Explode()
	{
		PopupTextPoolManager.Instance.SpawnPopup("damage", transform.position, explodeDamage.ToString("F0"));
		player.GetComponent<PlayerStats>().TakeDamage(explodeDamage);
		ObjectPooler.Instance.ReturnToPool("ExplodingMonster", gameObject);
	}
}
