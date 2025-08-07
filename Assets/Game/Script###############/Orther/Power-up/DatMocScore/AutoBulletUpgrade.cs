using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBulletUpgrade : MonoBehaviour
{
    public PlayerShooting playerShooting; // Gắn trong Inspector
    public int scoreToLevel2 = 500;
    public int scoreToLevel3 = 1000;

    private bool upgradedToLevel2 = false;
    private bool upgradedToLevel3 = false;

    void Update()
    {
        int currentScore = ScoreManager.Instance.CurrentScore;

        if (!upgradedToLevel2 && currentScore >= scoreToLevel2)
        {
            upgradedToLevel2 = true;
            playerShooting.bulletLevel = Mathf.Max(playerShooting.bulletLevel, 2);
            Debug.Log("Tự động nâng đạn lên Level 2");
        }

        if (!upgradedToLevel3 && currentScore >= scoreToLevel3)
        {
            upgradedToLevel3 = true;
            playerShooting.bulletLevel = Mathf.Max(playerShooting.bulletLevel, 3);
            Debug.Log("Tự động nâng đạn lên Level 3");
        }
    }
}
