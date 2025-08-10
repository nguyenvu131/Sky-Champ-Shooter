using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBug : MonoBehaviour {

	public float moveSpeed = 1.5f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
