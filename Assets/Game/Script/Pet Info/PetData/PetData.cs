using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PetData {
    public string petName;
    public Sprite icon;
    public int level;
    public float attack;
    public float fireRate;
    public GameObject bulletPrefab;
    public GameObject skillPrefab; // skill gắn sẵn script (vd: HealSkill.cs)
}
