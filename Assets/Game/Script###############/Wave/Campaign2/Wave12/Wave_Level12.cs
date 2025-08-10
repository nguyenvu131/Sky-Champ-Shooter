using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Level12 : MonoBehaviour {

	public GameObject monsterPrefab;
    public int rowCount = 2;
    public int monstersPerRow = 4;
    public float spacingX = 2.0f;
    public float spacingY = 1.5f;
    public Transform spawnOrigin;

    void Start()
    {
        SpawnZigzagShooters();
    }

    void SpawnZigzagShooters()
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < monstersPerRow; col++)
            {
                Vector3 spawnPos = spawnOrigin.position + new Vector3(spacingX * col - (monstersPerRow - 1) * spacingX / 2, -row * spacingY, 0);
                Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
