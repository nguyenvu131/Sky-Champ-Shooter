using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level38 : MonoBehaviour {

	public Transform spawnRoot;
    public GameObject smallAsteroidPrefab;
    public GameObject bigAsteroidPrefab;
    public GameObject sneakyEnemyPrefab;

    private float spawnDuration = 20f;
    private float spawnInterval = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnAsteroidBarrage());
    }

    IEnumerator SpawnAsteroidBarrage()
    {
        float timer = 0f;

        while (timer < spawnDuration)
        {
            float rand = Random.value;

            if (rand < 0.7f)
            {
                SpawnSmallAsteroid();
            }
            else if (rand < 0.95f)
            {
                SpawnBigAsteroid();
            }
            else
            {
                SpawnSneakyEnemy();
            }

            timer += spawnInterval;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnSmallAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-2.5f, 2.5f), 6.5f, 0f);
        GameObject asteroid = Instantiate(smallAsteroidPrefab, spawnPos, Quaternion.identity, spawnRoot);
        asteroid.AddComponent<Asteroid>().Init(3f);
    }

    void SpawnBigAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-2.2f, 2.2f), 6.8f, 0f);
        GameObject asteroid = Instantiate(bigAsteroidPrefab, spawnPos, Quaternion.identity, spawnRoot);
        asteroid.AddComponent<BigAsteroid>().Init(1.8f);
    }

    void SpawnSneakyEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-2f, 2f), 6.5f, 0f);
        GameObject enemy = Instantiate(sneakyEnemyPrefab, spawnPos, Quaternion.identity, spawnRoot);
        enemy.AddComponent<SneakyEnemy>();
    }
}
