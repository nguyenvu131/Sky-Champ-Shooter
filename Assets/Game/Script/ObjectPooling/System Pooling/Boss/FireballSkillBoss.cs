using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkillBoss : BaseBossSkill
{
    public float speed = 10f;
    public float lifeTime = 3f;
    private float timer;

    void OnEnable()
    {
        timer = lifeTime;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            BossSkillPoolManager.Instance.ReturnSkill(BossSkillType.Fireball, this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Gây damage
            BossSkillPoolManager.Instance.ReturnSkill(BossSkillType.Fireball, this);
        }
    }
}
