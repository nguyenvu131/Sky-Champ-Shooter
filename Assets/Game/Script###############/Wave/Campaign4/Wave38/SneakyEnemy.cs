using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakyEnemy : MonoBehaviour {

	private float speed = 2f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }
}
