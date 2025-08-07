using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level31 : MonoBehaviour {

	public GameObject enemyVerticalPrefab;
    public GameObject enemyHorizontalPrefab;
    public Transform spawnRoot;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnCrossfire());
    }

    IEnumerator SpawnCrossfire()
    {
        // Dọc từ trên xuống
        for (int i = -2; i <= 2; i++)
        {
            Vector3 spawnPos = new Vector3(i * 1.5f, 6f, 0);
            GameObject enemy = SpawnEnemy(enemyVerticalPrefab, spawnPos, Vector3.down);
            spawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1.0f);

        // Ngang từ trái sang
        for (int i = -2; i <= 2; i++)
        {
            Vector3 spawnPos = new Vector3(-8f, i * 1.5f, 0);
            GameObject enemy = SpawnEnemy(enemyHorizontalPrefab, spawnPos, Vector3.right);
            spawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1.0f);

        // Ngang từ phải sang
        for (int i = -2; i <= 2; i++)
        {
            Vector3 spawnPos = new Vector3(8f, i * 1.5f, 0);
            GameObject enemy = SpawnEnemy(enemyHorizontalPrefab, spawnPos, Vector3.left);
            spawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(0.3f);
        }
    }

    GameObject SpawnEnemy(GameObject prefab, Vector3 position, Vector3 moveDir)
    {
        GameObject enemy = Instantiate(prefab, position, Quaternion.identity, spawnRoot);
        enemy.AddComponent<SimpleEnemyMove>().moveDirection = moveDir;
        enemy.AddComponent<CrossfireShooter>(); // Gắn bắn đạn chữ X
        return enemy;
    }
}
