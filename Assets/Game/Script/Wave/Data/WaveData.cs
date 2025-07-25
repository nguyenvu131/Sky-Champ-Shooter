using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum WaveType
{
	Normal,
	Swarm,
	Formation,
	Elite,
	MiniBoss,
	Boss,
	Reward,
	Event
}

[System.Serializable]
public class WaveEnemyDataMonster
{
    public string monsterTag; // tag để gọi object từ ObjectPool
    public int count;         // số lượng quái
    public float spawnDelay;  // delay giữa từng quái
}

[System.Serializable]
public class WaveEnemy {
    public string enemyType;       // Tên pool (ví dụ: "Monster1")
    public int count;              // Số lượng spawn
    public float spawnDelay;       // Khoảng cách spawn giữa mỗi quái
}

[System.Serializable]
public class WaveData : MonoBehaviour
{
	public string waveName;
	public int enemyCount;
	public float spawnRate;
	public List<string> enemyTags; // ex: "Enemy_Normal", "Enemy_Shooter"
	public bool isBossWave;

	//
	public List<EnemySpawnData> enemyList;
	public float waveDelay = 2f; // Delay trước khi sang wave mới
	//
	public List<WaveEnemyDataMonster> enemies;
	//
	
	public float spawnTime; // thời gian xuất hiện wave
    public List<MonsterSpawnData> monsters;

	//Số lượng quái mỗi wave
	int GetMonsterCount(int wave)
	{
		return Mathf.Clamp(Mathf.FloorToInt(3 + wave * 1.5f), 3, 100);
	}

	//Level monster theo wave
	int CalculateMonsterLevel(int wave)
	{
		return Mathf.FloorToInt(1 + wave * 0.8f); // hoặc wave * 1.2f nếu bạn muốn tăng mạnh
	}

	//Xác suất Elite/Boss
	bool IsElite(int wave)
	{
		float chance = Mathf.Clamp(5f + wave * 0.5f, 5f, 30f); // %
		return Random.Range(0f, 100f) < chance;
	}

	bool IsBossWave(int wave)
	{
		return wave % 5 == 0; // Boss mỗi 5 wave
	}



}


