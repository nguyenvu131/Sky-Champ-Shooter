using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLeader : MonoBehaviour {

	public float speed = 1.5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
