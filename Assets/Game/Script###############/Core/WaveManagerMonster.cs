using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveManagerMonster : MonoBehaviour
{
    [Serializable]
    public class WaveInfo
    {
        public string waveName;
        public GameObject wavePrefab;
        public float delayBeforeStart = 1f;
        public int difficultyLevel = 1;
        public string victoryCondition = "KillAll"; // "KillAll", "SurviveTime"
        public float surviveTime = 0f; // dùng nếu là SurviveTime
    }

    [Header("Wave Settings")]
    public List<WaveInfo> waves = new List<WaveInfo>();
    public bool autoStart = true;
    public bool loopWaves = false;
    public bool autoNextWave = true;
    public float interWaveDelay = 2f;

    [Header("Runtime State")]
    public int currentWaveIndex = 0;
    private GameObject currentWaveInstance;
    private int aliveEnemies = 0;
    private bool isWaveRunning = false;
    private Coroutine currentWaveCoroutine;
    private float surviveTimer = 0f;

    public static Action<string> OnWaveStarted;
    public static Action<string> OnWaveCompleted;
    public static Action OnAllWavesCompleted;

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
        yield return new WaitForSeconds(waves[index].delayBeforeStart);
        StartWave(index);
    }

    public void StartWave(int index)
    {
        if (index < 0 || index >= waves.Count)
        {
            Debug.LogWarning("Invalid wave index.");
            return;
        }

        StopCurrentWave();
        currentWaveIndex = index;

        WaveInfo waveInfo = waves[currentWaveIndex];
        currentWaveInstance = Instantiate(waveInfo.wavePrefab, Vector3.zero, Quaternion.identity) as GameObject;

        MonsterSpawner spawner = currentWaveInstance.GetComponent<MonsterSpawner>();
        if (spawner != null)
        {
            spawner.OnMonsterSpawned += IncreaseEnemyCount;
            spawner.OnMonsterDied += DecreaseEnemyCount;
        }

        isWaveRunning = true;

        if (waveInfo.victoryCondition == "SurviveTime" && waveInfo.surviveTime > 0)
        {
            surviveTimer = waveInfo.surviveTime;
            currentWaveCoroutine = StartCoroutine(SurviveCountdown());
        }

        if (OnWaveStarted != null)
        {
            OnWaveStarted(waveInfo.waveName);
        }

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

        Debug.LogWarning("Wave name not found: " + waveName);
    }

    public void NextWave()
    {
        currentWaveIndex++;

        if (currentWaveIndex >= waves.Count)
        {
            if (loopWaves)
            {
                currentWaveIndex = 0;
            }
            else
            {
                Debug.Log("[WaveManager] All waves completed.");
                if (OnAllWavesCompleted != null)
                {
                    OnAllWavesCompleted();
                }
                isWaveRunning = false;
                return;
            }
        }

        StartCoroutine(WaitAndStartNextWave());
    }

    IEnumerator WaitAndStartNextWave()
    {
        isWaveRunning = false;
        yield return new WaitForSeconds(interWaveDelay);
        StartCoroutine(DelayedStart(currentWaveIndex));
    }

    public void RestartCurrentWave()
    {
        StartCoroutine(DelayedStart(currentWaveIndex));
    }

    public void StopCurrentWave()
    {
        if (currentWaveCoroutine != null)
        {
            StopCoroutine(currentWaveCoroutine);
        }

        if (currentWaveInstance != null)
        {
            Destroy(currentWaveInstance);
            currentWaveInstance = null;
        }

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
        {
            OnWaveCompleted(waves[currentWaveIndex].waveName);
        }
        
        Debug.Log("[WaveManager] Wave Completed: " + waves[currentWaveIndex].waveName);

        if (autoNextWave)
        {
            NextWave();
        }
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

    

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.N)) NextWave();
        if (Input.GetKeyDown(KeyCode.L)) RestartCurrentWave();
        if (Input.GetKeyDown(KeyCode.S)) StopCurrentWave();
#endif
    }
}