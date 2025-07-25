using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour {

	public float speed = 4f;
    private Vector3 moveDirection = Vector3.left;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
