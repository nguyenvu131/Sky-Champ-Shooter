using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthBar : MonoBehaviour
{
   public string displayName = "Enemy";
    public Sprite iconSprite;

    public float maxHP = 100;
    public float currentHP = 100;

    public GameObject healthBarPrefab;
    private HealthBar healthBar;

    void Start()
    {
        GameObject hb = Instantiate(healthBarPrefab, GameObject.Find("Canvas").transform);
        healthBar = hb.GetComponent<HealthBar>();
        healthBar.SetTarget(this.transform);
        healthBar.SetFill(currentHP, maxHP);
        healthBar.SetInfo(displayName, iconSprite);
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;

        if (healthBar != null)
            healthBar.SetFill(currentHP, maxHP);

        if (currentHP <= 0)
        {
            if (healthBar != null) healthBar.Show(false);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
