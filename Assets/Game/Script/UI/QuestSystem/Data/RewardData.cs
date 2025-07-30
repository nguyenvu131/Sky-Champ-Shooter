using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Main,
    Daily,
    Side,
    Event
}

public enum QuestConditionType
{
    KillEnemy,
    CompleteLevel,
    UseSkill,
    CollectItem
}

[System.Serializable]
public class RewardData
{
    public int gold;
    public int gem;
    public int exp;
    public string itemID;
}
