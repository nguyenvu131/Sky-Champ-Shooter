using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level27 : MonoBehaviour {

	public GameObject shadowEnemyPrefab;
    public int swarmCount = 4;
    public int enemiesPerSwarm = 3;
    public float spawnInterval = 1f;
    public Vector2 spawnRangeX = new Vector2(-5f, 5f);
    public float spawnY = 6f;

    void Start()
    {
        StartCoroutine(SpawnShadowSwarms());
    }

    IEnumerator SpawnShadowSwarms()
    {
        for (int i = 0; i < swarmCount; i++)
        {
            for (int j = 0; j < enemiesPerSwarm; j++)
            {
                Vector3 spawnPos = new Vector3(
                    Random.Range(spawnRangeX.x, spawnRangeX.y),
                    spawnY + j * 0.5f,
                    0
                );

                Instantiate(shadowEnemyPrefab, spawnPos, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
