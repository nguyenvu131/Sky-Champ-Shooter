using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignWaveManager : MonoBehaviour {

	public CampaignDataMonster campaignDataMonster; // dữ liệu toàn màn chơi
    public Transform[] spawnPoints;

    private int currentWaveIndex = 0;
    public bool isSpawning = false;
	
	public GameObject monster;

    void Start()
    {
        StartCoroutine(StartCampaign());
    }

    IEnumerator StartCampaign()
    {
        while (currentWaveIndex < campaignDataMonster.waves.Count)
        {
            yield return StartCoroutine(SpawnWave(campaignDataMonster.waves[currentWaveIndex]));
            currentWaveIndex++;

            yield return new WaitForSeconds(campaignDataMonster.delayBetweenWaves);
        }

        Debug.Log(" Campaign Complete!");
    }

    IEnumerator SpawnWave(WaveData wave)
    {
        isSpawning = true;

        foreach (WaveEnemyDataMonster enemy in wave.enemies)
        {
            for (int i = 0; i < enemy.count; i++)
            {
                Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

				monster = ObjectPooler.Instance.SpawnFromPool(enemy.monsterTag, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(enemy.spawnDelay);
            }
        }

        isSpawning = false;
        yield return null;
    }
}
