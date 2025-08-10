using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet17 : MonoBehaviour {

	public float speed = 5f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 6)
            Destroy(gameObject);
    }
}
