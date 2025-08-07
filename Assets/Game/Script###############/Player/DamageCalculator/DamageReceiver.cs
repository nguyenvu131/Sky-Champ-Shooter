using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public float defense = 10f;
    public Health health;

    public void TakeDamage(DamageInfo info)
    {
        float dmg = DamageCalculator.CalculateDamage(info, defense);
        health.ReduceHP(dmg);

        // Show damage popup
        DamagePopup.Create(transform.position, dmg, info.isCritical);
    }
}