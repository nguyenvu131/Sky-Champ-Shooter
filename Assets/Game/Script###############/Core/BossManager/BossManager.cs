using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance;

    [System.Serializable]
    public class BossWave
    {
        public string waveName;
        public GameObject bossPrefab;         // Prefab boss
        public Transform spawnPoint;          // Vị trí xuất hiện boss
    }

    [Header("Boss Settings")]
    public List<BossWave> bossWaves = new List<BossWave>();

    private GameObject currentBoss;
    private string currentWave = "";

	public WaveManagerMonster waveManager;
	
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        WaveManagerMonster.OnWaveStarted += OnWaveStarted;
    }

    void OnDestroy()
    {
        WaveManagerMonster.OnWaveStarted -= OnWaveStarted;
    }

    void OnWaveStarted(string waveName)
    {
        currentWave = waveName;

        BossWave bossWave = bossWaves.Find(b => b.waveName == waveName);
        if (bossWave != null)
        {
            SpawnBoss(bossWave);
        }
    }

    public void SpawnBoss(BossWave bossWave)
	{
		// Xóa hết quái thường
		if (waveManager != null)
			waveManager.ClearAllEnemiesFromList();

		if (bossWave.bossPrefab == null || bossWave.spawnPoint == null)
		{
			Debug.LogWarning("[BossManager] Missing boss prefab or spawn point.");
			return;
		}

		currentBoss = Instantiate(bossWave.bossPrefab, bossWave.spawnPoint.position, Quaternion.identity);
		PlayerShooting.Instance.playerShoot = false;
        Invoke(nameof(PlayerShoot), 1f); 
		// Đăng ký boss vào hệ thống wave
		if (WaveManagerMonster.Instance != null)
		{
			WaveManagerMonster.Instance.RegisterBoss(currentBoss);
		}

		Debug.Log("[BossManager] Boss spawned: " + bossWave.bossPrefab.name);
	}
    void PlayerShoot()
    {
        PlayerShooting.Instance.playerShoot = true;
    }
    void OnBossDead()
    {
        Debug.Log("[BossManager] Boss defeated: " + currentWave);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnBossDefeated(currentWave);
        }

        currentBoss = null;
    }

    public bool IsBossAlive()
    {
        return currentBoss != null;
    }

    public void ForceKillBoss()
    {
        if (currentBoss != null)
        {
            Destroy(currentBoss);
            currentBoss = null;
        }
    }
}
