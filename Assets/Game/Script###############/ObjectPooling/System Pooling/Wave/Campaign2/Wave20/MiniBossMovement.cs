using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossMovement : MonoBehaviour {

	public float moveSpeed = 1f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = new Vector3(transform.position.x, 3.5f, 0); // Dừng giữa màn hình
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
