using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PetData", menuName = "Pet/NewPet")]
public class PetData : ScriptableObject
{
    // public string petName;
    // public GameObject prefab;
    // public List<PetStats> levelStats;
    // public Sprite icon;
	
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
	
	// public string petID;
    // public GameObject petPrefab;
    // public PetType petType;
    // public int level;
    // public bool isActive;
	
	public string id;
    public PetType type;
    public int level;
    public GameObject prefab;
    public Sprite icon;
    public string description;

    public float GetAttackRate() {
        return 1.0f - (level * 0.05f); // Cấp càng cao, bắn càng nhanh
    }

    public int GetDamage() {
        return 10 + level * 2;
    }
}
