using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{	
	public PlayerStats stats;
	public int level = 1;
	public int HP;
    public int ATK;
    public float DEF;
    public int SPD;
    public int EXPToLevelUp;
	
    void Start()
    {
        CalculateStats(level);
    }

    public void CalculateStats(int level)
    {
        this.level = Mathf.Clamp(level, 1, 100);

        // HP: 100 + (level - 1) * 20
        HP = 100 + (level - 1) * 20;

        // ATK: 10 + (level - 1) * 2
        ATK = 10 + (level - 1) * 2;

        // DEF: 0.9 + (level - 1) * 0.01, giới hạn max 0.99
        DEF = Mathf.Min(0.9f + (level - 1) * 0.01f, 0.99f);

        // SPD: 5 + floor((level - 1)/3)
        SPD = 5 + Mathf.FloorToInt((level - 1) / 3);

        // EXPToLevelUp: 100 * floor(level ^ 1.5)
        EXPToLevelUp = Mathf.FloorToInt(100f * Mathf.Pow(level, 1.5f));
    }
}
