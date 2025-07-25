using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerMonster4 : MonoBehaviour {

	public MonsterSpawnData[] waves;
    public Transform spawnParent;

    public float timer = 0f;
    public int currentWaveIndex = 0;

    public void StartWave(int waveIndex)
    {
        if (waveIndex < 0 || waveIndex >= waves.Length) return;

        currentWaveIndex = waveIndex;
        StartCoroutine(SpawnWaveCoroutine(waves[waveIndex]));
    }

    private IEnumerator SpawnWaveCoroutine(MonsterSpawnData data)
    {
        foreach (var info in data.monstersToSpawn)
        {
            yield return new WaitForSeconds(info.startTime);

            for (int i = 0; i < info.count; i++)
            {
                Vector2 spawnPos = info.spawnPosition;

                if (info.useRandomOffset)
                {
                    float offsetX = Random.Range(-info.offsetRange, info.offsetRange);
                    float offsetY = Random.Range(-info.offsetRange, info.offsetRange);
                    spawnPos += new Vector2(offsetX, offsetY);
                }

                SpawnMonster(info.monsterData, spawnPos, info.level);

                yield return new WaitForSeconds(info.spawnDelay);
            }
        }
    }

    private void SpawnMonster(MonsterData monsterData, Vector2 position, int level)
    {
        // GameObject monsterGO = ObjectPoolingManager.Instance.Spawn(monsterData.monsterID, position, Quaternion.identity, spawnParent);
        // MonsterAI ai = monsterGO.GetComponent<MonsterAI>();
        // ai.Initialize(monsterData, level);
    }
}
