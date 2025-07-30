using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCampaign", menuName = "Campaign/CampaignData")]
public class CampaignData : ScriptableObject {
    public string campaignName;
    public int campaignID;
    public Sprite campaignThumbnail;
    public List<LevelData1> levels = new List<LevelData1>();
}
