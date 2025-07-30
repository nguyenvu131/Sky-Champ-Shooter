using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerAll : MonoBehaviour
{
    public List<WaveData> waveLevels = new List<WaveData>();
    public Transform monsterParent;

    public int currentWave = 0;
    private bool isWaveRunning = false;
	
	void Start()
	{
		waveLevels = new List<WaveData>(); // Khởi tạo danh sách các wave

		for (int i = 1; i <= 10; i++) // Lặp từ Level 1 đến Level 10
		{
			WaveData wave = new WaveData(); // Tạo 1 wave mới

			for (int j = 0; j < i + 2; j++) // Mỗi wave có số quái = level + 2
			{
				SpawnInfo spawn = new SpawnInfo();

				// Load prefab quái từ thư mục Resources/Monsters
				spawn.monsterPrefab = Resources.Load<GameObject>("Monsters/BasicEnemy");

				// Set thời gian spawn (cách nhau 1s)
				spawn.spawnTime = j * 1.0f;

				// Vị trí spawn ngẫu nhiên trên trục X (giả sử -2 đến 2), trục Y cố định (phía trên màn hình)
				spawn.spawnPosition = new Vector2(Random.Range(-2f, 2f), 6f);

				wave.spawnList.Add(spawn); // Thêm vào danh sách spawn của wave
			}

			waveLevels.Add(wave); // Thêm wave vào danh sách tổng
		}

		StartWave(0); // Bắt đầu wave đầu tiên (Level 1)
	}
	
    public void StartWave(int waveIndex)
    {
        if (waveIndex >= waveLevels.Count) return;

        currentWave = waveIndex;
        StartCoroutine(SpawnWaveCoroutine(waveLevels[waveIndex]));
    }

    private IEnumerator SpawnWaveCoroutine(WaveData wave)
    {
        isWaveRunning = true;

        foreach (var spawnInfo in wave.spawnList)
        {
            yield return new WaitForSeconds(spawnInfo.spawnTime);
            Instantiate(spawnInfo.monsterPrefab, spawnInfo.spawnPosition, Quaternion.identity, monsterParent);
        }

        isWaveRunning = false;
    }

    public bool IsWaveRunning()
    {
        return isWaveRunning;
    }
	
	
}
