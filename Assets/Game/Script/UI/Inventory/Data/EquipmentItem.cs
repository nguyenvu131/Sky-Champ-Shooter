using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentItem {
	public PlayerStats stats;
	
    public string itemName;
    public string itemID;
    public EquipmentType type;
    public Sprite icon;

    public int addHP;
    public float addATK;
    public float addDEF;
    public float addSPD;
    public float addFireRate;
    public float addCrit;

    // public int level;
}


