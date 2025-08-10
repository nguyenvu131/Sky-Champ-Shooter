using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStealthCloaker : MonoBehaviour {

	public float speed = 2f;
    public float appearDistance = 3.5f;
    public float fadeSpeed = 2f;
    public SpriteRenderer spriteRenderer;
    private Transform player;
    private float alpha = 0f;
    private bool isVisible = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        SetAlpha(0f);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (!isVisible && distance < appearDistance)
        {
            // Fade in
            alpha += Time.deltaTime * fadeSpeed;
            SetAlpha(Mathf.Clamp01(alpha));

            if (alpha >= 0.99f)
            {
                isVisible = true;
                Invoke("Shoot", 0.3f); // bắn sau khi hiện ra
            }
        }
    }

    void SetAlpha(float value)
    {
        if (spriteRenderer == null) return;
        Color c = spriteRenderer.color;
        c.a = value;
        spriteRenderer.color = c;
    }

    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    void Shoot()
    {
        if (bulletPrefab == null || player == null) return;
        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet15>().SetDirection(dir);
    }
}
