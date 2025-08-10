using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTypeAPrefab;
    public GameObject enemyTypeBPrefab;

    private Dictionary<string, GameObject> enemyPrefabs;

    private List<EnemySpawnInfo> waveData;

    private float timer = 0f;
    private int spawnIndex = 0;

    void Start()
    {
        enemyPrefabs = new Dictionary<string, GameObject>();
        enemyPrefabs.Add("EnemyTypeA", enemyTypeAPrefab);
        enemyPrefabs.Add("EnemyTypeB", enemyTypeBPrefab);

        waveData = WaveDataLevel1.GetWaves();
    }

    void Update()
    {
        if (spawnIndex >= waveData.Count)
            return;

        timer += Time.deltaTime;

        while (spawnIndex < waveData.Count && timer >= waveData[spawnIndex].spawnTime)
        {
            SpawnEnemy(waveData[spawnIndex]);
            spawnIndex++;
        }
    }

    void SpawnEnemy(EnemySpawnInfo spawnInfo)
    {
        GameObject prefab;
        if (enemyPrefabs.TryGetValue(spawnInfo.enemyType, out prefab))
        {
            Instantiate(prefab, spawnInfo.spawnPosition, Quaternion.identity);
			GameObject enemy = Instantiate(prefab, spawnInfo.spawnPosition, Quaternion.identity);
			enemy.SetActive(true); // bật đối tượng vừa tạo ra (thường không cần vì Instantiate mặc định đã active)
        }
        else
        {
            Debug.LogWarning("Enemy type not found: " + spawnInfo.enemyType);
        }
    }
}
