using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public int Level;
    public float HP;
    public float ATK;
    public float DEF;
    public float Speed;
    public int ExpDrop;
    public int GoldDrop;
    public float SkillCooldown;

    public void CalculateStats(int level)
    {
        Level = level;
        HP = 1000 + 400 * Mathf.Pow(level, 1.5f);
        ATK = 20 + 8 * Mathf.Pow(level, 1.2f);
        DEF = 5 + 3 * level;
        Speed = 1.2f - 0.01f * level;
        ExpDrop = 100 + 20 * level;
        GoldDrop = 50 + 10 * level;
        SkillCooldown = Mathf.Max(1.5f, 5f - 0.2f * level);
    }
}
