using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterSpawnInfo
{
	public MonsterData monsterData; // dữ liệu monster
	public int level = 1;
    public int count = 1;
    public float spawnDelay = 1f; // khoảng cách giữa từng con
    public float startTime = 0f;  // thời gian tính từ đầu wave
    public Vector2 spawnPosition;
    public bool useRandomOffset = false;
    public float offsetRange = 1f;
    }

[CreateAssetMenu(fileName = "MonsterSpawnData", menuName = "Wave/Create New Monster Spawn Data")]
public class MonsterSpawnData : ScriptableObject
{
    public string waveID;
    public MonsterSpawnInfo[] monstersToSpawn;

	public GameObject monsterPrefab;
    public Vector2 spawnPosition;
    public int amount;
    public float spawnInterval; // thời gian giữa các lần spawn cùng loại
}

