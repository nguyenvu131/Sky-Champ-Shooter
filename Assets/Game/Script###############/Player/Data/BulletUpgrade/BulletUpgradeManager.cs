using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgradeManager : MonoBehaviour {

	public BulletData bulletData;
    public int currentLevel = 0;

    public BulletLevelData GetCurrentLevelData()
    {
        return bulletData.levels[Mathf.Clamp(currentLevel, 0, bulletData.levels.Count - 1)];
    }

    public void UpgradeBullet()
    {
        currentLevel++;
        currentLevel = Mathf.Clamp(currentLevel, 0, bulletData.levels.Count - 1);
    }

    public void ResetUpgrade()
    {
        currentLevel = 0;
    }
}
