using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerFm : MonoBehaviour {

	public int currentMap = 1;
	public int currentWave = 1;
	public Transform[] spawnPoints;
	public GameObject[] monsterPrefabs;

	public GameObject player;

	void SpawnMonster()
	{
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject prefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

		GameObject monster = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

		int playerLevel = player.GetComponent<PlayerStats>().level;
		float timeAlive = Time.timeSinceLevelLoad;

		MonsterStats stats = monster.GetComponent<MonsterStats>();
		stats.Init(currentMap, currentWave, playerLevel, timeAlive);
	}
}
