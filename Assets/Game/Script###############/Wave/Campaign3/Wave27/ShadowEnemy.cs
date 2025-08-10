using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEnemy : MonoBehaviour {

	public float moveSpeed = 2.5f;
    public float detectionRange = 6f;
    public float invisibilityDuration = 1.5f;
    public float shootInterval = 2f;
    public GameObject bulletPrefab;
    
    private Transform player;
    private float shootTimer;
    private float invisibleTimer;
    private bool isVisible = false;
    private SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        shootTimer = shootInterval;
        invisibleTimer = invisibilityDuration;

        // Start invisible
        SetVisible(false);
    }

    void Update()
    {
        // Di chuyển xuống dưới
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // Hiện hình sau thời gian hoặc khi tấn công
        invisibleTimer -= Time.deltaTime;
        if (!isVisible && invisibleTimer <= 0f)
        {
            SetVisible(true);
        }

        // Nếu đã hiện hình, bắt đầu bắn
        if (isVisible && player != null)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f && Vector3.Distance(transform.position, player.position) < detectionRange)
            {
                ShootAtPlayer();
                shootTimer = shootInterval;
            }
        }

        if (transform.position.y < -7f)
            Destroy(gameObject);
    }

    void ShootAtPlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet27>().Init(dir);

        // Khi bắn sẽ hiện hình ngay lập tức nếu còn tàng hình
        if (!isVisible)
        {
            SetVisible(true);
        }
    }

    void SetVisible(bool visible)
    {
        isVisible = visible;
        sr.color = visible ? Color.white : new Color(1f, 1f, 1f, 0.1f); // alpha thấp khi tàng hình
    }
}
