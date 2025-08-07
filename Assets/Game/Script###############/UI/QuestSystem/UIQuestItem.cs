using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestItem : MonoBehaviour {

	public Text questNameText;
    public Slider progressSlider;
    public Button claimButton;
	//private
    public QuestData currentQuest;

    public void Setup(QuestData quest)
    {
        currentQuest = quest;
        questNameText.text = quest.questName;
        progressSlider.maxValue = quest.conditionAmount;
        progressSlider.value = quest.currentAmount;

        claimButton.interactable = quest.isCompleted && !quest.isClaimed;
        claimButton.onClick.RemoveAllListeners();
        claimButton.onClick.AddListener(() =>
        {
            QuestManager.Instance.ClaimReward(quest.questID);
        });
    }
}
