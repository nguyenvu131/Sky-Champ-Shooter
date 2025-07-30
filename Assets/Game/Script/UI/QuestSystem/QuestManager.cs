using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public static QuestManager Instance;

    public List<QuestData> allQuests = new List<QuestData>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadQuests();
    }

    void LoadQuests()
    {
        // Có thể load từ Resources/Quest hoặc từ JSON/XML
        allQuests = Resources.Load<QuestDatabase>("Quest/QuestDatabase").questList;
    }

    public void UpdateQuestProgress(QuestConditionType condition, int amount)
    {
        foreach (var quest in allQuests)
        {
            if (!quest.isCompleted && quest.conditionType == condition)
            {
                quest.currentAmount += amount;
                if (quest.currentAmount >= quest.conditionAmount)
                {
                    quest.currentAmount = quest.conditionAmount;
                    quest.isCompleted = true;
                    UIManagerQuest.Instance.ShowQuestCompletePopup(quest);
                }
            }
        }
    }

    public void ClaimReward(int questID)
    {
        QuestData quest = allQuests.Find(q => q.questID == questID);
        if (quest != null && quest.isCompleted && !quest.isClaimed)
        {
            // Thêm phần thưởng
            // PlayerData.Instance.AddGold(quest.reward.gold);
            // PlayerData.Instance.AddGem(quest.reward.gem);
            // quest.isClaimed = true;
			int gold = PlayerPrefs.GetInt("Gold", 0);
			PlayerPrefs.SetInt("Gold", gold + quest.reward.gold);

			int gem = PlayerPrefs.GetInt("Gem", 0);
			PlayerPrefs.SetInt("Gem", gem + quest.reward.gem);

			quest.isClaimed = true;
			Debug.Log("Claimed reward for quest: " + quest.questName);
        }
    }
}
