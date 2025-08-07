using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void ReduceHP(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Play death effect, drop loot, etc.
        Destroy(gameObject);
    }
}
