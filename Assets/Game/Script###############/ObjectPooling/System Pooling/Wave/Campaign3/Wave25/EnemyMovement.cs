using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement25 : MonoBehaviour {

	public float moveSpeed = 3f;
    private Vector3 moveDirection = Vector3.left;

    public void InitDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Tự hủy nếu ra khỏi màn hình
        if (transform.position.x < -12 || transform.position.x > 12)
            Destroy(gameObject);
    }
}
