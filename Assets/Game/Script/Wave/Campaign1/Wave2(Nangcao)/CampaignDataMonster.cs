using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CampaignData", menuName = "Campaign/New Campaign")]
public class CampaignDataMonster : ScriptableObject
{
    public List<WaveData> waves;
    public float delayBetweenWaves = 2f;
}