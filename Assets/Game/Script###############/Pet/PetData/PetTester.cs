using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTester : MonoBehaviour
{
    public PetLevelManager petLevelManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Nhấn E để test tăng EXP
        {
            // petLevelManager.GainExp(100);
            // Debug.Log("Level: " + petLevelManager.stats.level);
            // Debug.Log("Damage: " + petLevelManager.stats.damage);
            // Debug.Log("Cooldown: " + petLevelManager.stats.skillCooldown);
        }
    }
}
