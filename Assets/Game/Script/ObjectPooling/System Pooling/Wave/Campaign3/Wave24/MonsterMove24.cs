using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove24 : MonoBehaviour {

	public float moveSpeed = 3f;
    private Vector3 targetPosition;
    private bool hasTarget = false;

    public void MoveTo(Vector3 pos)
    {
        targetPosition = pos;
        hasTarget = true;
    }

    void Update()
    {
        if (hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                hasTarget = false;
        }
    }
}
