using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level17 : MonoBehaviour {

	public GameObject meteorPrefab;
    public GameObject escortEnemyPrefab;
    public int meteorCount = 3;
    public float spacingX = 2.5f;
    public Transform spawnCenter;
	public GameObject meteor;

    void Start()
    {
        SpawnMeteorEscort();
    }

    void SpawnMeteorEscort()
    {
        for (int i = 0; i < meteorCount; i++)
        {
            Vector3 spawnPos = spawnCenter.position + new Vector3((i - meteorCount / 2) * spacingX, 0, 0);

            // Spawn Meteor
            meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

            // Spawn Escort Enemy slightly behind meteor
            Vector3 escortPos = spawnPos + new Vector3(0, -0.5f, 0);
            GameObject escort = Instantiate(escortEnemyPrefab, escortPos, Quaternion.identity);

            // Cho quái follow meteor hoặc bay cùng hướng
            var escortAI = escort.GetComponent<EscortEnemy>();
            if (escortAI != null)
                escortAI.SetTargetDirection(Vector2.down);
        }
    }
}
