using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	private float speed = 3f;

    public void Init(float moveSpeed)
    {
        speed = moveSpeed;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Nếu va chạm với đạn hoặc người chơi => nổ
        if (other.CompareTag("PlayerBullet") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
            // Có thể thêm hiệu ứng nổ ở đây
        }
    }
}
