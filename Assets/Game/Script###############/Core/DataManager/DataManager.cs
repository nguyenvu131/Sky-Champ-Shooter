using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES3Internal; // Nếu lỗi thì bỏ dòng này

[System.Serializable]
public class GameData
{
    public int currentWaveIndex;
    public GameState gameState;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public GameData currentData = new GameData();

    private const string saveKey = "GameDataJson";

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        // DontDestroyOnLoad(gameObject);
    }

    public void SaveGame(int waveIndex, GameState state)
    {
        currentData.currentWaveIndex = waveIndex;
        currentData.gameState = state;

        // Chuyển object thành JSON string
        string json = JsonUtility.ToJson(currentData);

        // Lưu json string bằng ES3
        ES3.Save<string>(saveKey, json);

        Debug.Log("[DataManager] Game Saved as JSON string");
    }

    public void LoadGame()
    {
        if (ES3.KeyExists(saveKey))
        {
            string json = ES3.Load<string>(saveKey);

            // Chuyển JSON string về object
            currentData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("[DataManager] Game Loaded from JSON string");
        }
        else
        {
            Debug.Log("[DataManager] No save data found");
        }
    }

    public void ClearSave()
    {
        ES3.DeleteKey(saveKey);
        Debug.Log("[DataManager] Save data cleared");
    }
}
