using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level14 : MonoBehaviour {

	public GameObject monsterPrefab;
    public int swarmCount = 20;
    public float spawnInterval = 0.1f;
    public float spawnAreaWidth = 6f;
    public bool spawnFromLeft = true;

    void Start()
    {
        StartCoroutine(SpawnSwarm());
    }

    IEnumerator SpawnSwarm()
    {
        for (int i = 0; i < swarmCount; i++)
        {
            float randomY = Random.Range(-4f, 4f); // Vùng spawn theo Y
            Vector3 spawnPos;

            if (spawnFromLeft)
                spawnPos = new Vector3(-spawnAreaWidth / 2f - 1f, randomY, 0f); // trái
            else
                spawnPos = new Vector3(spawnAreaWidth / 2f + 1f, randomY, 0f); // phải

            GameObject monster = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
            MonsterSwarmAI ai = monster.GetComponent<MonsterSwarmAI>();
            if (ai != null)
                ai.moveDirection = spawnFromLeft ? Vector2.right : Vector2.left;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
