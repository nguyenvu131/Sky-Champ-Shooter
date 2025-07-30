using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// khi chien thang
// public void OnLevelWin()
// {
    // int currentLevelID = CampaignManager.Instance.currentLevel.levelID;
    // int nextLevelID = currentLevelID + 1;

    // CampaignProgressManager.Instance.UnlockNextLevel(nextLevelID);

    // WinLoseManager.Instance.WinGame(); // popup thắng
// }

public class CampaignUIManager : MonoBehaviour {

	public Transform campaignButtonRoot;
    public GameObject campaignButtonPrefab;

    public Transform levelButtonRoot;
    public GameObject levelButtonPrefab;

    void Start()
    {
        CreateCampaignButtons();
    }

    void CreateCampaignButtons()
    {
        foreach (var camp in CampaignManager.Instance.allCampaigns)
        {
            GameObject btn = Instantiate(campaignButtonPrefab, campaignButtonRoot);
            btn.GetComponentInChildren<Text>().text = camp.campaignName;

            btn.GetComponent<Button>().onClick.AddListener(() => {
                CampaignManager.Instance.SelectCampaign(camp.campaignID);
                CreateLevelButtons();
            });
        }
    }

    void CreateLevelButtons()
    {
        foreach (Transform child in levelButtonRoot)
            Destroy(child.gameObject);

        foreach (var level in CampaignManager.Instance.currentCampaign.levels)
        {
            GameObject btn = Instantiate(levelButtonPrefab, levelButtonRoot);
            btn.GetComponentInChildren<Text>().text = "Level " + level.levelID;

            bool isUnlocked = CampaignProgressManager.Instance.levelProgressDict.ContainsKey(level.levelID)
                              && CampaignProgressManager.Instance.levelProgressDict[level.levelID].isUnlocked;

            btn.GetComponent<Button>().interactable = isUnlocked;

            btn.GetComponent<Button>().onClick.AddListener(() => {
                CampaignManager.Instance.SelectLevel(level.levelID);
                SceneManager.LoadScene("Mapgame"); // load gameplay
            });
        }
    }
}
