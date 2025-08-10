using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyMove : MonoBehaviour {

	public Vector2 moveDirection = Vector2.zero;
    public float moveSpeed = 3f;

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f || Mathf.Abs(transform.position.x) > 10f)
            Destroy(gameObject);
    }
}
