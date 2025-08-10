using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level19 : MonoBehaviour {

	public GameObject wallEnemyPrefab;
    public int rows = 5;
    public float verticalSpacing = 1.2f;
    public float wallSpeed = 1.5f;

    void Start()
    {
        SpawnWall(-1); // Bên trái
        SpawnWall(1);  // Bên phải
    }

    void SpawnWall(int direction) // -1 là trái, 1 là phải
    {
        float xPos = direction * 7f; // Spawn ngoài màn hình
        float yStart = 4f;

        for (int i = 0; i < rows; i++)
        {
            Vector3 spawnPos = new Vector3(xPos, yStart - i * verticalSpacing, 0);
            GameObject enemy = Instantiate(wallEnemyPrefab, spawnPos, Quaternion.identity);
            enemy.AddComponent<WallEnemy>().moveDirection = new Vector3(-direction, 0, 0); // ép vào giữa
            enemy.GetComponent<WallEnemy>().moveSpeed = wallSpeed;
        }
    }
}
