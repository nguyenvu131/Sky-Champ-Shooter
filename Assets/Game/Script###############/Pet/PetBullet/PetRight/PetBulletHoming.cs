using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletHoming : MonoBehaviour {

	public float speed = 5f;
    public float rotateSpeed = 200f;
    public float damage = 10f;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            // Di chuyển thẳng nếu không có target
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            return;
        }

        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(transform.right, direction).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
