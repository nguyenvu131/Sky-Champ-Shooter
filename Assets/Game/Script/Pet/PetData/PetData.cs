using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PetData", menuName = "Pet/NewPet")]
public class PetData : ScriptableObject
{
    public string petName;
    public GameObject prefab;
    public List<PetStats> levelStats;
    public Sprite icon;
	
	// public string petName;
    // public Sprite icon;
    // public int level;
	// public int hp;
    // public float attack;
	// public float shotRate;
    // public string unlockSkill;
    // public float fireRate;
    // public GameObject bulletPrefab;
    // public GameObject skillPrefab; // skill gắn sẵn script (vd: HealSkill.cs)
}
