using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
	public string enemyType;             // "Drone", "Shooter", "Boss"
	public GameObject prefab;            // Prefab tương ứng
	public int count;                    // Số lượng spawn
	public float spawnDelay = 0.5f;      // Delay giữa từng con
	
	public GameObject monsterPrefab;
    public Vector2 spawnPosition;
    public int amount;
    public float spawnInterval; // thời gian giữa các lần spawn cùng loại
}
