using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDatabase", menuName = "Game Data/Quest Database")]
public class QuestDatabase : ScriptableObject
{
    public List<QuestData> questList = new List<QuestData>();
}
