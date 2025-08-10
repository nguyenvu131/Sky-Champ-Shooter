using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBoss
{
    void InitBoss();
    void TakeDamage(float damage);
    void OnBossDefeated();
}

public abstract class BossBase : MonoBehaviour, IBoss
{
    [Header("Boss Info")]
    public string bossName;
    public float maxHealth;
    public float currentHealth;
    public int bossLevel;
    public float moveSpeed;
    public bool isDefeated;

    [Header("Stats")]
    public MonsterStats stats; // Hiển thị đầy đủ trong Inspector

    [Header("Effects & UI (Auto Load)")]
    public string hitEffectName = "HitEffect";         // Tên prefab trong Resources/Bosses
    public string damagePopupName = "DamagePopup";     // Tên prefab trong Resources/Bosses
    public Color flashColor = Color.red;               // Màu flash khi bị trúng đòn
    public float flashDuration = 0.1f;

    protected Transform player;
    protected Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private GameObject hitEffectPrefab;
    private GameObject damagePopupPrefab;


	
    protected virtual void Start()
    {
        LoadResources();
        InitBoss();
    }

    // Load prefab từ Resources/Effects
    private void LoadResources()
    {
        hitEffectPrefab = Resources.Load<GameObject>("Effects/" + hitEffectName);
        damagePopupPrefab = Resources.Load<GameObject>("Effects/" + damagePopupName);

        if (hitEffectPrefab == null)
            Debug.LogWarning("Không tìm thấy HitEffect trong Resources/Effects/" + hitEffectName);

        if (damagePopupPrefab == null)
            Debug.LogWarning("Không tìm thấy DamagePopup trong Resources/Effects/" + damagePopupName);
    }

    public virtual void InitBoss()
    {
        currentHealth = maxHealth;
        isDefeated = false;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;
    }

    public virtual void TakeDamage(float damage)
    {
        if (isDefeated) return;

        float finalDamage = damage - stats.defense;
        finalDamage = Mathf.Max(finalDamage, 1);
        stats.currentHP -= finalDamage;

        ShowDamagePopup(damage);
        PlayHitEffect();
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
            OnBossDefeated();
    }

    public virtual void OnBossDefeated()
    {
        isDefeated = true;
        Debug.Log(bossName + " defeated!");
        Destroy(gameObject, 1f);
    }

    // Hiển thị popup damage
    protected void ShowDamagePopup(float damage)
    {
       
    }

    // Hiệu ứng trúng đòn
    protected void PlayHitEffect()
    {
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }
    }

    // Flash màu khi bị trúng đòn
    private System.Collections.IEnumerator FlashRed()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
        }
    }

    protected abstract void BossAttackPattern();
}
