using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner3 : MonoBehaviour {

	public string enemyTag = "Enemy";
	public float spawnRate = 2f;
	public Transform[] spawnPoints;
	
	void Start()
	{
		InvokeRepeating("SpawnEnemy", 1f, spawnRate);
	}
	
	void SpawnEnemy()
	{
		int i = Random.Range(0, spawnPoints.Length);
		PoolManager.Instance.SpawnFromPool(enemyTag, spawnPoints[i].position, Quaternion.identity);
	}
}
