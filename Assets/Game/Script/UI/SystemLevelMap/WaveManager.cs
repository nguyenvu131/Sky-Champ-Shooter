using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
     public Transform spawnRoot;
    public List<WaveStats> waveList = new List<WaveStats>();

    private int currentWaveIndex = 0;
    public bool isPlaying = false;

    private List<GameObject> aliveEnemies = new List<GameObject>();

    [Header("Boss Settings")]
    public GameObject bossPrefab;
    private GameObject currentBoss;
    public GameObject bossWarningUI;
    public AudioClip bossSpawnSFX;
    private AudioSource audioSource;

    [Header("Wave Settings")]
    public float delayBetweenWaves = 1f;
    public bool autoStartNextWave = true;

    public System.Action onAllWavesCompleted;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void LoadWavesForLevel(int level)
    {
        waveList.Clear();
        currentWaveIndex = 0;

        Object[] waveAssets = Resources.LoadAll("Waves/Level" + level, typeof(WaveStats));
        foreach (var obj in waveAssets)
        {
            waveList.Add((WaveStats)obj);
        }

        waveList.Sort((a, b) => a.waveID.CompareTo(b.waveID));

        // Load Boss prefab
        GameObject loadedBoss = Resources.Load<GameObject>("Bosses/Level" + level);
        if (loadedBoss != null)
        {
            bossPrefab = loadedBoss;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy Boss cho Level " + level);
        }
    }

    public void StartWave()
    {
        isPlaying = true;
        StartCoroutine(RunWaves());
    }

    IEnumerator RunWaves()
    {
        for (int i = 0; i < waveList.Count; i++)
        {
            currentWaveIndex = i;
            WaveStats wave = waveList[i];

            yield return StartCoroutine(RunWave(wave));
            yield return new WaitUntil(() => aliveEnemies.Count == 0);
            yield return new WaitForSeconds(delayBetweenWaves);
        }

        // Spawn Boss nếu có
        if (bossPrefab != null)
        {
            yield return StartCoroutine(SpawnBoss());
        }

        Debug.Log("TẤT CẢ WAVE + BOSS ĐÃ HOÀN THÀNH");

        isPlaying = false;

        // Thông báo cho GameManager hoặc các system khác
        if (onAllWavesCompleted != null)
            onAllWavesCompleted.Invoke();
        else
            GameManager.Instance.OnLevelCompleted(); // fallback nếu không set callback
    }

    IEnumerator RunWave(WaveStats wave)
    {
        foreach (var spawn in wave.spawns)
        {
            StartCoroutine(SpawnSingle(spawn));
        }

        foreach (var formation in wave.formations)
        {
            StartCoroutine(SpawnFormation(formation));
        }

        float duration = GetWaveDuration(wave);
        yield return new WaitForSeconds(duration + 1f);
    }

    IEnumerator SpawnSingle(SpawnInfo info)
    {
        yield return new WaitForSeconds(info.spawnTime);
        SpawnEnemy(info.monsterPrefab, info.spawnPosition);
    }

    IEnumerator SpawnFormation(FormationSpawnInfo info)
    {
        yield return new WaitForSeconds(info.startTime);

        for (int i = 0; i < info.count; i++)
        {
            Vector3 pos = new Vector3(info.startX, info.startY + i * info.ySpacing, 0);
            GameObject enemy = Instantiate(info.prefab, pos, Quaternion.identity, spawnRoot);

            MonsterMove move = enemy.GetComponent<MonsterMove>();
            if (move != null)
                move.SetDirection(Vector3.left);

            aliveEnemies.Add(enemy);

            var death = enemy.GetComponent<EnemyDeathHandler>();
            if (death != null)
            {
                death.onDeath += () =>
                {
                    aliveEnemies.Remove(enemy);
                    GameManager.Instance.OnEnemyDefeated();
                };
            }

            Destroy(enemy, 10f);
            yield return new WaitForSeconds(info.interval);
        }
    }

    float GetWaveDuration(WaveStats wave)
    {
        float maxTime = 0f;

        foreach (var s in wave.spawns)
        {
            if (s.spawnTime > maxTime)
                maxTime = s.spawnTime;
        }

        foreach (var f in wave.formations)
        {
            float formationTime = f.startTime + f.interval * f.count;
            if (formationTime > maxTime)
                maxTime = formationTime;
        }

        return maxTime;
    }

    private void SpawnEnemy(GameObject prefab, Vector3 position)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab null khi spawn enemy");
            return;
        }

        GameObject enemy = Instantiate(prefab, position, Quaternion.identity, spawnRoot);

        MonsterMove move = enemy.GetComponent<MonsterMove>();
        if (move != null)
            move.SetDirection(Vector3.left);

        aliveEnemies.Add(enemy);

        EnemyDeathHandler death = enemy.GetComponent<EnemyDeathHandler>();
        if (death != null)
        {
            death.onDeath += () =>
            {
                aliveEnemies.Remove(enemy);
                GameManager.Instance.OnEnemyDefeated();
            };
        }

        Destroy(enemy, 10f);
    }

    IEnumerator SpawnBoss()
    {
        Debug.Log("Xuất hiện Boss!");

        // Hiển thị UI Cảnh báo Boss
        if (bossWarningUI != null)
        {
            bossWarningUI.SetActive(true);
            yield return new WaitForSeconds(2f);
            bossWarningUI.SetActive(false);
        }

        // Phát âm thanh Boss (nếu có)
        if (bossSpawnSFX != null)
            audioSource.PlayOneShot(bossSpawnSFX);

        currentBoss = Instantiate(bossPrefab, new Vector3(5, 0, 0), Quaternion.identity, spawnRoot);
        aliveEnemies.Add(currentBoss);

        MonsterMove move = currentBoss.GetComponent<MonsterMove>();
        if (move != null)
            move.SetDirection(Vector3.left);

        EnemyDeathHandler death = currentBoss.GetComponent<EnemyDeathHandler>();
        if (death != null)
        {
            death.onDeath += () =>
            {
                aliveEnemies.Remove(currentBoss);
                GameManager.Instance.OnEnemyDefeated();
                Debug.Log("Boss đã bị tiêu diệt!");
            };
        }

        yield return new WaitUntil(() => currentBoss == null || !currentBoss.activeInHierarchy || aliveEnemies.Count == 0);
        yield return new WaitForSeconds(1f);
    }

    public bool AllWavesCompleted()
    {
        return currentWaveIndex >= waveList.Count - 1;
    }

    public bool AllEnemiesDefeated()
    {
        return aliveEnemies.Count == 0;
    }
}
