using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave21_Snake : MonoBehaviour {

	public GameObject snakeEnemyPrefab; // Prefab quái thường
    public int snakeLength = 7;         // Số lượng quái trong 1 đoàn
    public float spawnDelay = 0.3f;     // Delay giữa mỗi quái
    public float startX = -4f;          // Vị trí X bắt đầu
    public float startY = 6f;           // Vị trí Y bắt đầu

    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnSnake());
    }

    IEnumerator SpawnSnake()
    {
        for (int i = 0; i < snakeLength; i++)
        {
            Vector3 spawnPos = new Vector3(startX, startY + i * 0.5f, 0);
            GameObject enemy = Instantiate(snakeEnemyPrefab, spawnPos, Quaternion.identity);
            
            // Gán offset vào script di chuyển
            SnakeEnemyMove move = enemy.GetComponent<SnakeEnemyMove>();
            if (move != null)
                move.offset = i * 0.5f;

            enemies.Add(enemy);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
