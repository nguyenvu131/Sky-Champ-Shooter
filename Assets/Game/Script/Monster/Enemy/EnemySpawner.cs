using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float spawnInterval = 2f;
	public Transform[] spawnPoints;
	public string[] enemyTags; // tương ứng với các tag trong EnemyPool

	private float timer;
	public GameObject enemy;

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= spawnInterval)
		{
			SpawnEnemy();
			timer = 0f;
		}
	}

	void SpawnEnemy()
	{
		if (spawnPoints.Length == 0 || enemyTags.Length == 0)
			return;

		Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
		string randomTag = enemyTags[Random.Range(0, enemyTags.Length)];

		enemy = EnemyPool.Instance.SpawnFromPool(randomTag, point.position, Quaternion.identity);
		
	}
}
