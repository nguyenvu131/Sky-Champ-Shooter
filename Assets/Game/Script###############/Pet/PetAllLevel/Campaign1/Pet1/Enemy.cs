using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour 
{
	public Action OnDeath;
	public float hp = 100f;

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
            Die();
    }

    public void ApplyBurn(float duration, float dps)
    {
        StartCoroutine(BurnCoroutine(duration, dps));
    }

    IEnumerator BurnCoroutine(float duration, float dps)
    {
        float t = 0f;
        while (t < duration)
        {
            TakeDamage(dps * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
    }

    void Die()
    {
        // Add death effects here
        Destroy(gameObject);
    }
}
