using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class WaveManagerMonster : MonoBehaviour
{
    public static WaveManagerMonster Instance;

    public enum WaveSpawnType
    {
        Prefab, // spawn từ prefab
        Data    // spawn từ class dữ liệu
    }

    [Serializable]
    public class WaveInfo
    {
        public string waveName;
        public WaveSpawnType spawnType = WaveSpawnType.Prefab;
        public GameObject wavePrefab; // dùng nếu Prefab
        public string waveDataClassName; // dùng nếu Data

        public float delayBeforeStart = 1f;
        public int difficultyLevel = 1;
        public string victoryCondition = "KillAll"; // "KillAll", "SurviveTime"
        public float surviveTime = 0f; // nếu SurviveTime
    }

    [Header("Wave Settings")] // 👈 Hiển thị tiêu đề "Wave Settings" trong Inspector của Unity để nhóm các biến cấu hình cho dễ quản lý
	public List<WaveInfo> waves = new List<WaveInfo>(); // 👈 Danh sách tất cả các wave (mỗi wave chứa thông tin quái, độ khó, kiểu spawn, v.v.)
	public bool autoStart = true; // 👈 Nếu true thì khi game bắt đầu sẽ tự chạy wave đầu tiên
	public bool loopWaves = false; // 👈 Nếu true thì sau wave cuối cùng sẽ quay lại wave đầu tiên
	public bool autoNextWave = true; // 👈 Nếu true thì khi một wave hoàn thành sẽ tự động chuyển sang wave tiếp theo
	public float interWaveDelay = 2f; // 👈 Thời gian nghỉ giữa các wave (tính bằng giây)

	[Header("Runtime State")] // 👈 Tiêu đề "Runtime State" trong Inspector để nhóm các biến trạng thái khi game đang chạy
	public int currentWaveIndex = 0; // 👈 Chỉ số wave hiện tại (bắt đầu từ 0)
	private GameObject currentWaveInstance; // 👈 GameObject đại diện cho wave đang chạy (nếu spawn từ prefab)
	private int aliveEnemies = 0; // 👈 Số lượng quái đang còn sống trong wave hiện tại
	private bool isWaveRunning = false; // 👈 Trạng thái cho biết wave hiện tại có đang chạy hay không
	private Coroutine currentWaveCoroutine; // 👈 Lưu coroutine đếm thời gian survive hoặc các quá trình khác của wave
	private Coroutine spawnCoroutine; // 👈 Lưu coroutine spawn quái nếu dùng chế độ Data
	private float surviveTimer = 0f; // 👈 Bộ đếm thời gian còn lại nếu victoryCondition là "SurviveTime"

	public static Action<string> OnWaveStarted; // 👈 Event được gọi khi một wave bắt đầu, truyền vào tên wave
	public static Action<string> OnWaveCompleted; // 👈 Event được gọi khi một wave hoàn thành, truyền vào tên wave
	public static Action OnAllWavesCompleted; // 👈 Event được gọi khi tất cả wave đã hoàn thành
	
	// ✅ Danh sách lưu tất cả quái thường
    private List<GameObject> aliveEnemyList = new List<GameObject>();
	
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (autoStart)
        {
            StartCoroutine(DelayedStart(currentWaveIndex));
        }
    }

    IEnumerator DelayedStart(int index)
	{
		isWaveRunning = false;

		// Ngăn crash nếu index sai
		if (index < 0 || index >= waves.Count)
		{
			Debug.LogWarning("[WaveManager] DelayedStart() bị gọi với index ngoài phạm vi: " + index);
			yield break;
		}

		yield return new WaitForSeconds(waves[index].delayBeforeStart);
		StartWave(index);
	}

    public void StartWave(int index)
    {
        if (index < 0 || index >= waves.Count)
        {
            Debug.LogError("Wave index không tồn tại: " + index);
            return;
        }

        StopCurrentWave();
        currentWaveIndex = index;

        WaveInfo waveInfo = waves[currentWaveIndex];

        // ----- Prefab Mode -----
        if (waveInfo.spawnType == WaveSpawnType.Prefab && waveInfo.wavePrefab != null)
        {
            currentWaveInstance = Instantiate(waveInfo.wavePrefab, Vector3.zero, Quaternion.identity) as GameObject;

            MonsterSpawner spawner = currentWaveInstance.GetComponent<MonsterSpawner>();
            if (spawner != null)
            {
                spawner.OnMonsterSpawned += delegate(GameObject enemy)
                {
                    IncreaseEnemyCount(enemy);
                };

                spawner.OnMonsterDied += delegate(GameObject enemy)
                {
                    DecreaseEnemyCount(enemy);
                };
            }

            isWaveRunning = true;
        }
        // ----- Data Mode -----
        else if (waveInfo.spawnType == WaveSpawnType.Data && !string.IsNullOrEmpty(waveInfo.waveDataClassName))
        {
            List<EnemySpawnInfo> spawnList = GetWaveDataByName(waveInfo.waveDataClassName);
            if (spawnList != null && spawnList.Count > 0)
            {
                isWaveRunning = true;
                spawnCoroutine = StartCoroutine(SpawnEnemiesFromData(spawnList));
            }
            else
            {
                Debug.LogWarning("[WaveManager] No spawn data found for wave: " + waveInfo.waveName);
            }
        }
		
		// Kiểm tra nếu là Boss Wave
		if (waveInfo.waveName.Contains("Boss"))
		{
			BossSpawner bossSpawner = FindObjectOfType<BossSpawner>();
			if (bossSpawner != null)
			{
				bossSpawner.OnBossSpawned += delegate(GameObject boss)
				{
					Debug.Log("[WaveManager] Boss spawned for wave: " + waveInfo.waveName);
				};
				bossSpawner.SpawnBoss();
			}
		}
		
        // ----- Victory Condition -----
        if (waveInfo.victoryCondition == "SurviveTime" && waveInfo.surviveTime > 0)
        {
            surviveTimer = waveInfo.surviveTime;
            currentWaveCoroutine = StartCoroutine(SurviveCountdown());
        }

        if (OnWaveStarted != null)
            OnWaveStarted(waveInfo.waveName);

        Debug.Log("[WaveManager] Started Wave: " + waveInfo.waveName + " | Difficulty: " + waveInfo.difficultyLevel);
    }

    IEnumerator SurviveCountdown()
    {
        while (surviveTimer > 0 && isWaveRunning)
        {
            surviveTimer -= Time.deltaTime;
            yield return null;
        }

        if (surviveTimer <= 0)
        {
            Debug.Log("[WaveManager] SurviveTime reached! Completing wave.");
            CompleteWave();
        }
    }

    public void StartWaveByName(string waveName)
    {
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i].waveName == waveName)
            {
                StartWave(i);
                return;
            }
        }

        Debug.LogError("Không tìm thấy wave: " + waveName);
    }

    public void NextWave()
	{
		currentWaveIndex++;

		// Nếu vượt quá số wave, xử lý tùy chế độ
		if (currentWaveIndex >= waves.Count)
		{
			if (loopWaves && waves.Count > 0)
			{
				currentWaveIndex = 0; // quay lại wave đầu
			}
			else
			{
				Debug.Log("[WaveManager] All waves completed.");
				if (OnAllWavesCompleted != null)
					OnAllWavesCompleted();
				isWaveRunning = false;
				return; // ← Quan trọng: dừng hẳn, không gọi wave mới
			}
		}

		StartCoroutine(WaitAndStartNextWave());
	}

    IEnumerator WaitAndStartNextWave()
	{
		isWaveRunning = false;

		yield return new WaitForSeconds(interWaveDelay);

		if (currentWaveIndex < 0 || currentWaveIndex >= waves.Count)
		{
			Debug.LogWarning("[WaveManager] WaitAndStartNextWave() bị gọi với index ngoài phạm vi: " + currentWaveIndex);
			yield break; // Dừng hẳn coroutine này
		}

		StartCoroutine(DelayedStart(currentWaveIndex));
	}

    public void RestartCurrentWave()
    {
        StartCoroutine(DelayedStart(currentWaveIndex));
    }

    public void StopCurrentWave()
    {
        if (currentWaveCoroutine != null)
            StopCoroutine(currentWaveCoroutine);

        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);

        if (currentWaveInstance != null)
        {
            Destroy(currentWaveInstance);
            currentWaveInstance = null;
        }
		
		ClearAllEnemiesFromList();
        aliveEnemies = 0;
        surviveTimer = 0f;
        isWaveRunning = false;
    }

    public void IncreaseEnemyCount(GameObject enemy)
    {
        aliveEnemies++;
    }

    public void DecreaseEnemyCount(GameObject enemy)
    {
        aliveEnemies--;

        if (aliveEnemies <= 0 && waves[currentWaveIndex].victoryCondition == "KillAll")
        {
            CompleteWave();
        }
    }

    private void CompleteWave()
    {
        isWaveRunning = false;

        if (OnWaveCompleted != null)
            OnWaveCompleted(waves[currentWaveIndex].waveName);

        Debug.Log("[WaveManager] Wave Completed: " + waves[currentWaveIndex].waveName);

        if (autoNextWave)
            NextWave();
    }

    // ========= Boss =========
    public void RegisterBoss(GameObject boss)
    {
        aliveEnemies++;
        MonsterHealthBoss bossHealth = boss.GetComponent<MonsterHealthBoss>();
        if (bossHealth != null)
        {
            bossHealth.OnDeath += OnBossDead;
        }
    }

    private void OnBossDead()
    {
        aliveEnemies--;
        if (aliveEnemies <= 0 && waves[currentWaveIndex].victoryCondition == "KillAll")
        {
            CompleteWave();
        }
    }

    // ========= Data Mode Helpers =========
    private IEnumerator SpawnEnemiesFromData(List<EnemySpawnInfo> spawnList)
    {
        aliveEnemies = 0;

        for (int i = 0; i < spawnList.Count; i++)
        {
            yield return new WaitForSeconds(spawnList[i].spawnTime);
            SpawnEnemy(spawnList[i].enemyType, spawnList[i].spawnPosition);
        }
    }

    private void SpawnEnemy(string enemyType, Vector2 position)
    {
        GameObject enemyPrefab = Resources.Load<GameObject>("Enemies/" + enemyType);
        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity) as GameObject;
            IncreaseEnemyCount(enemy);

            MonsterHealth health = enemy.GetComponent<MonsterHealth>();
            if (health != null)
            {
                health.OnDeath += delegate { DecreaseEnemyCount(enemy); };
            }
        }
        else
        {
            Debug.LogWarning("[WaveManager] Enemy prefab not found: " + enemyType);
        }
    }

    private List<EnemySpawnInfo> GetWaveDataByName(string className)
    {
        Type t = Type.GetType(className);
        if (t != null)
        {
            MethodInfo method = t.GetMethod("GetWaves", BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                return method.Invoke(null, null) as List<EnemySpawnInfo>;
            }
        }
        Debug.LogWarning("[WaveManager] Wave data class not found: " + className);
        return null;
    }

    // ========= Helper methods =========
    public bool IsFinalWave()
    {
        return currentWaveIndex == waves.Count - 1;
    }

    public bool IsWaveRunning()
    {
        return isWaveRunning;
    }

    public bool IsWaveCompleted()
    {
        return !isWaveRunning && aliveEnemies <= 0;
    }

    public int GetAliveEnemyCount()
    {
        return aliveEnemies;
    }

    public WaveInfo GetCurrentWave()
    {
        if (currentWaveIndex >= 0 && currentWaveIndex < waves.Count)
        {
            return waves[currentWaveIndex];
        }
        return null;
    }
	
	// ✅ Hàm xóa toàn bộ quái thường
    public void ClearAllEnemiesFromList()
    {
        foreach (GameObject enemy in aliveEnemyList)
        {
            if (enemy != null)
                Destroy(enemy); // hoặc enemy.SetActive(false) nếu dùng Object Pool
        }
        aliveEnemyList.Clear();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.N)) NextWave();
        if (Input.GetKeyDown(KeyCode.L)) RestartCurrentWave();
        if (Input.GetKeyDown(KeyCode.S)) StopCurrentWave();
#endif
    }
}