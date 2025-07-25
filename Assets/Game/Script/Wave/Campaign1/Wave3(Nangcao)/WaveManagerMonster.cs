using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerMonster : MonoBehaviour {

	public GameObject[] monsterPrefabs; // Regular
	public GameObject elitePrefab;
	public GameObject bossPrefab;

	public Transform[] spawnPoints;
	public int currentWave = 1;

	public void SpawnWave()
	{
		int monsterCount = GetMonsterCount(currentWave);
		int monsterLevel = CalculateMonsterLevel(currentWave);
		bool isBossWave = IsBossWave(currentWave);

		if (isBossWave)
		{
			SpawnMonster(bossPrefab, monsterLevel, true, true);
		}
		else
		{
			for (int i = 0; i < monsterCount; i++)
			{
				GameObject prefab;
				bool elite = IsElite(currentWave);

				if (elite)
					prefab = elitePrefab;
				else
					prefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

				SpawnMonster(prefab, monsterLevel, elite, false);
			}
		}

		currentWave++;
	}

	void SpawnMonster(GameObject prefab, int level, bool elite, bool boss)
	{
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject m = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

		MonsterStats stats = m.GetComponent<MonsterStats>();
		stats.isElite = elite;
		stats.isBoss = boss;
		stats.Init(level);
	}

	int GetMonsterCount(int wave)
	{
		return Mathf.Clamp(Mathf.FloorToInt(3 + wave * 1.5f), 3, 100);
	}

	int CalculateMonsterLevel(int wave)
	{
		return Mathf.FloorToInt(1 + wave * 0.8f);
	}

	bool IsElite(int wave)
	{
		float chance = Mathf.Clamp(5f + wave * 0.5f, 5f, 30f);
		return Random.Range(0f, 100f) < chance;
	}

	bool IsBossWave(int wave)
	{
		return wave % 5 == 0;
	}
}
