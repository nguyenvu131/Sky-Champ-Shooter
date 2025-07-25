using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public List<WaveData> waves;
	public Transform[] spawnPoints;

	private int currentWave = 0;
	public bool isSpawning = false;

	void Start()
	{
		StartCoroutine(SpawnWave());
	}

	IEnumerator SpawnWave()
	{
		while (currentWave < waves.Count)
		{
			WaveData wave = waves[currentWave];
			Debug.Log("Wave Started: " + wave.waveName);

			isSpawning = true;

			for (int i = 0; i < wave.enemyCount; i++)
			{
				string tag = wave.enemyTags[Random.Range(0, wave.enemyTags.Count)];
				Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

				GameObject enemy = PoolManager.Instance.SpawnFromPool(tag, spawnPoint.position, Quaternion.identity);
				enemy.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

				yield return new WaitForSeconds(wave.spawnRate);
			}

			isSpawning = false;

			// Boss đặc biệt
			if (wave.isBossWave)
			{
				yield return new WaitForSeconds(2f);
				GameObject boss = PoolManager.Instance.SpawnFromPool("Boss", spawnPoints[0].position, Quaternion.identity);
				boss.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
			}

			// Chờ 5s để vào wave kế
			yield return new WaitForSeconds(5f);
			currentWave++;
		}

		Debug.Log("All waves finished!");
	}
}
