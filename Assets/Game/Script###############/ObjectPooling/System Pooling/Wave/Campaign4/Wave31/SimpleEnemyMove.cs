using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMove : MonoBehaviour {

	public Vector3 moveDirection = Vector3.down;
    public float moveSpeed = 2f;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f || Mathf.Abs(transform.position.x) > 10f)
            Destroy(gameObject);
    }
}
