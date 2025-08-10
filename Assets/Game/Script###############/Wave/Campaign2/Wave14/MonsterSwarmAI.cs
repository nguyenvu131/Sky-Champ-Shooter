using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSwarmAI : MonoBehaviour {

	public float speed = 6f;
    public Vector2 moveDirection = Vector2.right;

    void Update()
    {
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);

        // Tự hủy nếu ra khỏi màn hình (có thể dùng OnBecameInvisible)
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 6)
        {
            Destroy(gameObject);
        }
    }
}
