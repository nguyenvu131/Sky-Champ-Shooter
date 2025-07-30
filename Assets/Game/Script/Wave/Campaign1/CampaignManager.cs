using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CampaignManager : MonoBehaviour {

	public static CampaignManager Instance;

    public List<CampaignData> allCampaigns = new List<CampaignData>();
    public CampaignData currentCampaign;
    public LevelData1 currentLevel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadAllCampaigns();
    }

    void LoadAllCampaigns()
    {
        CampaignData[] loaded = Resources.LoadAll<CampaignData>("Campaigns");
        allCampaigns = loaded.ToList();
    }

    public void SelectCampaign(int id)
    {
        currentCampaign = allCampaigns.FirstOrDefault(c => c.campaignID == id);
    }

    public void SelectLevel(int levelId)
    {
        currentLevel = currentCampaign.levels.FirstOrDefault(l => l.levelID == levelId);
    }
}
