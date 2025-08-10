using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemy : MonoBehaviour {

	public Vector3 moveDirection;
    public float moveSpeed = 1.5f;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) < 0.5f) // Tới giữa thì dừng lại
        {
            moveSpeed = 0;
        }

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
