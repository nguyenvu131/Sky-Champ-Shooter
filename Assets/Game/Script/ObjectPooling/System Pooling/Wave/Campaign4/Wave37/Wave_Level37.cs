using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level37 : MonoBehaviour {

	public GameObject timeRiftEnemyPrefab;
    public Transform spawnRoot;

    private int totalRiftCycles = 3;
    private float delayBetweenCycle = 4f;

    private List<Vector3> spawnPositions = new List<Vector3>();

    void Start()
    {
        StartCoroutine(SpawnTimeRiftEnemies());
    }

    IEnumerator SpawnTimeRiftEnemies()
    {
        // Tạo đợt đầu tiên và lưu lại vị trí spawn
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(5.5f, 6.5f), 0f);
            spawnPositions.Add(pos);
            SpawnEnemy(pos);
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(delayBetweenCycle);

        // "Lặp thời gian" – spawn lại cùng vị trí, nhiều lần
        for (int cycle = 1; cycle < totalRiftCycles; cycle++)
        {
            foreach (Vector3 pos in spawnPositions)
            {
                SpawnEnemy(pos);
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(delayBetweenCycle);
        }
    }

    void SpawnEnemy(Vector3 position)
    {
        GameObject enemy = Instantiate(timeRiftEnemyPrefab, position, Quaternion.identity, spawnRoot);
        enemy.AddComponent<TimeRiftEnemy>(); // AI dịch chuyển thời gian
    }
}
