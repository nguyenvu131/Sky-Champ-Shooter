using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

	public float moveSpeed = 2f;
    private Vector3 moveDirection = Vector3.left;
	
    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
