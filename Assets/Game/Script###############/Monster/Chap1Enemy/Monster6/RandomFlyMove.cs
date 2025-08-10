using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlyMove : MonoBehaviour {

	public float moveSpeed = 2f;
    public float directionChangeInterval = 1.5f;

    private Vector2 currentDirection;

    void Start()
    {
        InvokeRepeating("ChangeDirection", 0f, directionChangeInterval);
    }

    void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        currentDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    void Update()
    {
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }

    void OnDisable()
    {
        CancelInvoke(); // quan trọng để không leak
    }
}
