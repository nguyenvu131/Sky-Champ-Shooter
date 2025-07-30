using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public int questID;
    public string questName;
    public string description;

    public QuestType questType;
    public QuestConditionType conditionType;

    public int conditionAmount;
    public int currentAmount;

    public bool isCompleted;
    public bool isClaimed;

    public RewardData reward;
}
