using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level32 : MonoBehaviour {

	public GameObject mirrorEnemyPrefab;
    public Transform spawnRoot;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnMirrorSplitWave());
    }

    IEnumerator SpawnMirrorSplitWave()
    {
        int mirrorPairCount = 5;
        float delay = 1f;

        for (int i = 0; i < mirrorPairCount; i++)
        {
            // Spawn một cặp kẻ địch ở giữa
            Vector3 centerPos = new Vector3(0, 6f, 0);
            GameObject leftEnemy = SpawnEnemy(centerPos, new Vector2(-1, -1).normalized);
            GameObject rightEnemy = SpawnEnemy(centerPos, new Vector2(1, -1).normalized);

            spawnedEnemies.Add(leftEnemy);
            spawnedEnemies.Add(rightEnemy);

            yield return new WaitForSeconds(delay);
        }
    }

    GameObject SpawnEnemy(Vector3 position, Vector2 moveDir)
    {
        GameObject enemy = Instantiate(mirrorEnemyPrefab, position, Quaternion.identity, spawnRoot);
        var mover = enemy.AddComponent<SplitEnemyMove>();
        mover.moveDirection = moveDir;
        return enemy;
    }
}
