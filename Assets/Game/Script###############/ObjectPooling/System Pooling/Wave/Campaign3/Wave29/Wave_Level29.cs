using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level29 : MonoBehaviour {

	public GameObject enemyPrefab;
    public float spawnDelay = 0.2f;

    void Start()
    {
        StartCoroutine(SpawnFormationRecall());
    }

    IEnumerator SpawnFormationRecall()
    {
        SpawnFormationZ(new Vector3(0, 5.5f, 0));
        yield return new WaitForSeconds(1.5f);

        SpawnFormationL(new Vector3(-4f, 4f, 0));
        yield return new WaitForSeconds(1.5f);

        SpawnLineFormation(new Vector3(0, 3f, 0));
    }

    void SpawnFormationZ(Vector3 startPos)
    {
        Vector2[] offsets = new Vector2[]
        {
            new Vector2(-1, 1), new Vector2(0, 1), new Vector2(1, 1),
            new Vector2(1, 0),
            new Vector2(-1, -1), new Vector2(0, -1), new Vector2(1, -1),
        };

        foreach (Vector2 offset in offsets)
        {
            Vector3 spawnPos = startPos + (Vector3)offset;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    void SpawnFormationL(Vector3 startPos)
    {
        Vector2[] offsets = new Vector2[]
        {
            new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, -1),
            new Vector2(1, -1), new Vector2(2, -1),
        };

        foreach (Vector2 offset in offsets)
        {
            Vector3 spawnPos = startPos + (Vector3)offset;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    void SpawnLineFormation(Vector3 startPos)
    {
        for (int i = -3; i <= 3; i++)
        {
            Vector3 pos = startPos + new Vector3(i, 0, 0);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
