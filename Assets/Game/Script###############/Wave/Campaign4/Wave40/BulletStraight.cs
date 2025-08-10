using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStraight : MonoBehaviour {

	private float speed = 3f;
    private Vector3 direction;

    public void Init(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.y < -6f || transform.position.y > 6f)
            Destroy(gameObject);
    }
}
