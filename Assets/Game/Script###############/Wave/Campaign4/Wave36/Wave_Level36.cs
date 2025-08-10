using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level36 : MonoBehaviour {

	public GameObject bulletHellEnemyPrefab;
    public Transform spawnRoot;

    private float spawnInterval = 0.7f;
    private int totalWaves = 6;
    private int enemiesPerWave = 5;

    void Start()
    {
        StartCoroutine(SpawnBulletHellEnemies());
    }

    IEnumerator SpawnBulletHellEnemies()
    {
        for (int wave = 0; wave < totalWaves; wave++)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(5f, 6f), 0f);
                GameObject enemy = Instantiate(bulletHellEnemyPrefab, spawnPos, Quaternion.identity, spawnRoot);

                BulletHellEnemy behavior = enemy.AddComponent<BulletHellEnemy>();
                behavior.shootInterval = 1.5f;
                behavior.rotationSpeed = Random.Range(60f, 120f); // tốc độ xoay đạn

                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
