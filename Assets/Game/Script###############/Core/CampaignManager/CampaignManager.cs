using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CampaignLevel
{
    public string levelName;
    public GameObject wavePrefab;    // Prefab chứa wave (ví dụ Wave_Level1)
    public bool isUnlocked = false;
}

public class CampaignManager : MonoBehaviour
{
    public static CampaignManager Instance;

    [Header("Campaign Settings")]
    public List<CampaignLevel> levels = new List<CampaignLevel>();
    public int currentLevelIndex = 0;
    private WaveManagerMonster waveManager;

    private const string PLAYER_PREFS_KEY = "CampaignProgress";

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        LoadProgress();
        waveManager = FindObjectOfType<WaveManagerMonster>();

        WaveManagerMonster.OnWaveCompleted += OnWaveCompleted;

        // Auto start current level if waveManager exists
        if (waveManager != null && levels.Count > 0)
        {
            StartCampaignLevel(currentLevelIndex);
        }
    }

    void OnDestroy()
    {
        WaveManagerMonster.OnWaveCompleted -= OnWaveCompleted;
    }

    // ===== CAMPAIGN CORE =====
    public void StartCampaignLevel(int index)
    {
        if (index < 0 || index >= levels.Count)
        {
            Debug.LogWarning("[CampaignManager] Invalid level index.");
            return;
        }

        currentLevelIndex = index;
        if (!levels[index].isUnlocked)
        {
            Debug.LogWarning("[CampaignManager] Level not unlocked.");
            return;
        }

        if (waveManager != null)
        {
            waveManager.waves.Clear(); // Clear old waves
            WaveManagerMonster.WaveInfo wave = new WaveManagerMonster.WaveInfo();
            wave.waveName = levels[index].levelName;
            wave.wavePrefab = levels[index].wavePrefab;
            waveManager.waves.Add(wave);

            waveManager.autoStart = true;
            waveManager.StartWave(0);
        }

        Debug.Log("[CampaignManager] Started level: " + levels[index].levelName);
    }

    void OnWaveCompleted(string waveName)
    {
        Debug.Log("[CampaignManager] Wave completed: " + waveName);

        // Unlock next level if exists
        if (currentLevelIndex + 1 < levels.Count)
        {
            levels[currentLevelIndex + 1].isUnlocked = true;
            SaveProgress();
            Debug.Log("[CampaignManager] Next level unlocked: " + levels[currentLevelIndex + 1].levelName);
        }
    }

    // ===== PROGRESS SAVE/LOAD =====
    void SaveProgress()
    {
        string data = "";
        for (int i = 0; i < levels.Count; i++)
        {
            data += levels[i].isUnlocked ? "1" : "0";
        }

        PlayerPrefs.SetString(PLAYER_PREFS_KEY, data);
        PlayerPrefs.Save();
    }

    void LoadProgress()
    {
        string data = PlayerPrefs.GetString(PLAYER_PREFS_KEY, "1" + new string('0', levels.Count - 1));

        for (int i = 0; i < data.Length && i < levels.Count; i++)
        {
            levels[i].isUnlocked = data[i] == '1';
        }
    }

    // ===== DEBUG KEYS =====
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1)) StartCampaignLevel(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) StartCampaignLevel(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) StartCampaignLevel(2);
#endif
    }
}
