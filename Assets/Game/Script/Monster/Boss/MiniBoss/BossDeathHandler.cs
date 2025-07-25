using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathHandler : MonoBehaviour {

	public GameObject dropItemPrefab;
	public GameObject explosionEffect;

	public void HandleDeath()
	{
		Instantiate(explosionEffect, transform.position, Quaternion.identity);
		Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
