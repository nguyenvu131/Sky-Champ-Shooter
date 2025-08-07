using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave24_AmbushSwarmSpawner : MonoBehaviour {

	public GameObject swarmPrefab;
    public int totalEnemies = 20;
    public float spawnDelay = 0.2f;

    void Start()
    {
        StartCoroutine(SpawnAmbushWave());
    }

    IEnumerator SpawnAmbushWave()
    {
        int spawned = 0;
        while (spawned < totalEnemies)
        {
            Vector2 spawnPos = GetRandomEdgePosition();
            GameObject enemy = ObjectPooler.Instance.SpawnFromPool("Swarmling", spawnPos, Quaternion.identity);
            
            Vector3 center = new Vector3(0, 0, 0); // trung tâm màn hình
            enemy.GetComponent<MonsterMove24>().MoveTo(center);

            spawned++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    Vector2 GetRandomEdgePosition()
    {
        int edge = Random.Range(0, 4);
        float x = 0, y = 0;

        switch (edge)
        {
            case 0: // Trên
                x = Random.Range(-5f, 5f);
                y = 6f;
                break;
            case 1: // Dưới
                x = Random.Range(-5f, 5f);
                y = -6f;
                break;
            case 2: // Trái
                x = -8f;
                y = Random.Range(-3f, 3f);
                break;
            case 3: // Phải
                x = 8f;
                y = Random.Range(-3f, 3f);
                break;
        }

        return new Vector2(x, y);
    }
}
