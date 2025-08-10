using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave23_Boomerang : MonoBehaviour {

	public GameObject boomerangEnemyPrefab;
    public int numberOfEnemies = 5;
    public float delayBetweenSpawns = 0.5f;
    public float spawnY = 6f;
    public float leftStartX = -3.5f;
    public float rightStartX = 3.5f;

    void Start()
    {
        StartCoroutine(SpawnBoomerangWave());
    }

    IEnumerator SpawnBoomerangWave()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Spawn từ trái
            Vector3 leftPos = new Vector3(leftStartX, spawnY, 0);
            GameObject leftEnemy = Instantiate(boomerangEnemyPrefab, leftPos, Quaternion.identity);
            BoomerangEnemyMove moveL = leftEnemy.GetComponent<BoomerangEnemyMove>();
            moveL.direction = 1; // bay qua phải

            // Spawn từ phải
            Vector3 rightPos = new Vector3(rightStartX, spawnY, 0);
            GameObject rightEnemy = Instantiate(boomerangEnemyPrefab, rightPos, Quaternion.identity);
            BoomerangEnemyMove moveR = rightEnemy.GetComponent<BoomerangEnemyMove>();
            moveR.direction = -1; // bay qua trái

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }
}
