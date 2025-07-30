using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeSkill : BaseBossSkill
{
    public float duration = 2f;
    private float timer;

    void OnEnable()
    {
        timer = duration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            BossSkillPoolManager.Instance.ReturnSkill(BossSkillType.LightningStrike, this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Gây damage
        }
    }
}
