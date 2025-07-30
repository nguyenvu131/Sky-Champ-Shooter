using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet12 : MonoBehaviour {

	public float speed = 5f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Tự hủy khi ra khỏi màn hình
    }
}
