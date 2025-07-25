using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI2 : MonoBehaviour {

	private Transform target;

    public void InitAI()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            transform.position += Vector3.down * Time.deltaTime * GetComponent<MonsterStats>().moveSpeed;
        }
    }
}
