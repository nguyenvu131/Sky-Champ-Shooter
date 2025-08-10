using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet2 : MonoBehaviour
{
    public float speed = 5f;              // Tốc độ di chuyển
    public float lifeTime = 5f;           // Thời gian sống
    public float damage = 10f;            // Sát thương gây ra

    private Vector2 moveDirection;

    void Start()
    {
        // Tự hủy sau lifeTime giây
        // Destroy(gameObject, lifeTime);

        // Lấy hướng bắn từ transform.rotation
        moveDirection = Vector2.down; // Mũi tên "Up" của prefab
    }

    void Update()
    {
        // Di chuyển theo hướng đã đặt
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Nếu chạm Player hoặc object có IDamageable thì gây damage
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject); // Xóa đạn sau khi bắn trúng
        }

        // Nếu chạm tường hoặc vùng ngoài map
        if (collision.CompareTag("Wall") || collision.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
