using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level5 : MonoBehaviour
{
    public GameObject enemyPrefab;     // Kéo prefab của SmallFly vào đây trong Inspector
    public int totalFlies = 15;
    public float spawnInterval = 0.15f;
    public float startX = 10f;
    public float centerY = 0f;
    public float yRandomRange = 1.5f;
	public GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnSwarm());
    }

    IEnumerator SpawnSwarm()
    {
        for (int i = 0; i < totalFlies; i++)
        {
            float randomY = Random.Range(-yRandomRange, yRandomRange);
            Vector3 spawnPos = new Vector3(startX, centerY + randomY, 0f);

            enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // Không cần SetActive(true), vì Instantiate mặc định đã active

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
