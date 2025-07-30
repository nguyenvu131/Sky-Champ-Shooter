using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampaignProgressManager : MonoBehaviour {

	public static CampaignProgressManager Instance;

    public Dictionary<int, LevelProgressData> levelProgressDict = new Dictionary<int, LevelProgressData>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadProgress();
    }

    public void UnlockNextLevel(int levelID)
    {
        if (!levelProgressDict.ContainsKey(levelID)) {
            levelProgressDict[levelID] = new LevelProgressData { levelID = levelID, isUnlocked = true, starsEarned = 0 };
        }
        else {
            levelProgressDict[levelID].isUnlocked = true;
        }

        SaveProgress();
    }

    public void SaveProgress()
    {
        string json = JsonUtility.ToJson(new Serialization<int, LevelProgressData>(levelProgressDict));
        PlayerPrefs.SetString("CampaignProgress", json);
    }

    public void LoadProgress()
    {
        string json = PlayerPrefs.GetString("CampaignProgress", "");
        if (!string.IsNullOrEmpty(json))
        {
            levelProgressDict = new Serialization<int, LevelProgressData>(json).ToDictionary();
        }
    }
}
