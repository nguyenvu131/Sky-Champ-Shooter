using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingEnemy : MonoBehaviour {

	private float moveSpeed = 3f;

    public void Init(float speed)
    {
        moveSpeed = speed;
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }
}
