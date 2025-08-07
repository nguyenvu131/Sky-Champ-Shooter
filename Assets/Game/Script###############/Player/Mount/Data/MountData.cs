using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MountData", menuName = "Mount/Create New Mount")]
public class MountData : ScriptableObject
{
    public string mountName;
    public GameObject mountPrefab;
    
    public int bonusHP;
    public int bonusAttack;
    public int bonusDefense;
    public float bonusSpeed;

    public Sprite icon;
    public SkillData mountSkill;

    public MountType type;
    public Rarity rarity;
}

public enum MountType { Beast, Mech, Spirit }
public enum Rarity { Common, Rare, Epic, Legendary }
