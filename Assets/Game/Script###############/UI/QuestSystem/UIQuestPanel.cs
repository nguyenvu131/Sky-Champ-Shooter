using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuestPanel : MonoBehaviour {

	public Transform questListRoot;
    public GameObject questItemPrefab;

    void OnEnable()
    {
        RefreshQuestUI();
    }

    public void RefreshQuestUI()
    {
        foreach (Transform child in questListRoot)
            Destroy(child.gameObject);

        foreach (var quest in QuestManager.Instance.allQuests)
        {
            GameObject item = Instantiate(questItemPrefab, questListRoot);
            item.GetComponent<UIQuestItem>().Setup(quest);
        }
    }
}
