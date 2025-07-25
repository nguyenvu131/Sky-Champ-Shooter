using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {

	public string[] enemyTags;
	public Transform[] spawnPoints;
	public float spawnInterval = 2f;
	private float timer;

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			SpawnEnemy();
			timer = spawnInterval;
		}
	}

	void SpawnEnemy()
	{
		int tagIndex = Random.Range(0, enemyTags.Length);
		int spawnIndex = Random.Range(0, spawnPoints.Length);

		PoolManager.Instance.SpawnFromPool(enemyTags[tagIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
	}
}
