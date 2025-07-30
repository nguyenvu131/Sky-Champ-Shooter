using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level18 : MonoBehaviour {

	public GameObject enemyPrefab;
    public int enemyCount = 6;
    public float radius = 2.5f;
    public Transform centerSpawnPoint;

    void Start()
    {
        SpawnRotatingGroup();
    }

    void SpawnRotatingGroup()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            float angle = i * Mathf.PI * 2f / enemyCount;
            Vector3 spawnPos = centerSpawnPoint.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            RotatingEnemy rot = enemy.GetComponent<RotatingEnemy>();
            if (rot != null)
            {
                rot.Setup(centerSpawnPoint.position, angle);
            }
        }
    }
}
