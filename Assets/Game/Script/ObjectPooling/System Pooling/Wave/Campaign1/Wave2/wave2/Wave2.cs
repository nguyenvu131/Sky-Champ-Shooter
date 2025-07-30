using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour 
{

	public GameObject[] monsterPrefabs;
	public Transform[] spawnPoints;
	public float spawnInterval = 5f;
	private float spawnTimer;
	public GameObject m;

	void Update()
	{
		spawnTimer += Time.deltaTime;
		if (spawnTimer >= spawnInterval)
		{
			SpawnMonster();
			spawnTimer = 0f;
		}
	}

	void SpawnMonster()
	{
		int rand = Random.Range(0, monsterPrefabs.Length);
		int spawnIndex = Random.Range(0, spawnPoints.Length);
		m = Instantiate(monsterPrefabs[rand], spawnPoints[spawnIndex].position, Quaternion.identity);
	}
}
