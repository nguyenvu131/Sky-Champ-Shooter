using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthBoss : MonoBehaviour
{
    public float maxHP = 100;
    private float currentHP;

    public delegate void OnDeathHandler();
    public event OnDeathHandler OnDeath;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (OnDeath != null)
            OnDeath.Invoke();

        Destroy(gameObject);
    }
}
