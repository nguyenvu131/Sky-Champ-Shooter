using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestSaveData
{
    public List<QuestData> savedQuests;
}

public class SaveLoadManager : MonoBehaviour
{
    public void SaveQuests()
    {
        QuestSaveData data = new QuestSaveData();
        data.savedQuests = QuestManager.Instance.allQuests;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("QuestSave", json);
    }

    public void LoadQuests()
    {
        string json = PlayerPrefs.GetString("QuestSave", "");
        if (!string.IsNullOrEmpty(json))
        {
            QuestSaveData data = JsonUtility.FromJson<QuestSaveData>(json);
            QuestManager.Instance.allQuests = data.savedQuests;
        }
    }
}
