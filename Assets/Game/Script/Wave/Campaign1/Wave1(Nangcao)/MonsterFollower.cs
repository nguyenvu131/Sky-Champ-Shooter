using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollower : MonoBehaviour 
{

	private Transform leader;
    private Vector3 offset;

    public float followSpeed = 3f;

    public void SetLeader(Transform t, Vector3 off)
    {
        leader = t;
        offset = off;
    }

    void Update()
    {
        if (leader != null)
        {
            Vector3 targetPos = leader.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
        }
    }
}
