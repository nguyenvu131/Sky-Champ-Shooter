using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerQuest : MonoBehaviour {

	public static UIManagerQuest Instance;

    public GameObject questCompletePopup;
    public Text questCompleteText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowQuestCompletePopup(QuestData quest)
    {
        if (questCompletePopup != null && questCompleteText != null)
        {
            questCompleteText.text = "Hoàn thành: " + quest.questName;
            questCompletePopup.SetActive(true);

            // Ẩn sau 2.5s
            Invoke("HideQuestCompletePopup", 2.5f);
        }
    }

    void HideQuestCompletePopup()
    {
        questCompletePopup.SetActive(false);
    }
}
