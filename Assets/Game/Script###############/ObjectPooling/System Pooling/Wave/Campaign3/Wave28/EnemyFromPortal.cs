using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFromPortal : MonoBehaviour {

	public float moveSpeed = 2.5f;
    private Vector3 targetDir;

    void Start()
    {
        // Bay xuống dưới theo góc lệch
        float angle = Random.Range(-30f, 30f);
        targetDir = Quaternion.Euler(0, 0, angle) * Vector3.down;
    }

    void Update()
    {
        transform.position += targetDir * moveSpeed * Time.deltaTime;

        if (transform.position.magnitude > 20f)
            Destroy(gameObject);
    }
}
