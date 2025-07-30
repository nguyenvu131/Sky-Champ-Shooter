using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level13 : MonoBehaviour {

	public GameObject monsterPrefab;
    public int numberOfEnemies = 5;
    public float spacingX = 2.0f;
    public float spawnHeight = 6f;
    public Transform centerSpawn;

    void Start()
    {
        SpawnBoomerangEnemies();
    }

    void SpawnBoomerangEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPos = centerSpawn.position + new Vector3((i - numberOfEnemies / 2) * spacingX, spawnHeight, 0);
            Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
        }
    }
}
