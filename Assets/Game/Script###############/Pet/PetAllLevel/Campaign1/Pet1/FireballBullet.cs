using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBullet : MonoBehaviour {

	public float speed = 8f;
    private Transform target;
    private float damage;
    private float burnChance;
    private float burnDuration;
    private float burnDPS;

    public void SetTarget(Transform t, float dmg, float burnChance, float burnTime, float burnDPS)
    {
        this.target = t;
        this.damage = dmg;
        this.burnChance = burnChance;
        this.burnDuration = burnTime;
        this.burnDPS = burnDPS;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            OnHit();
        }
    }

    void OnHit()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            if (Random.value < burnChance)
            {
                enemy.ApplyBurn(burnDuration, burnDPS);
            }
        }

        Destroy(gameObject);
    }
}
