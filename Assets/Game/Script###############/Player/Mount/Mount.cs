using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : MonoBehaviour
{
    public MountData data;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;
        Vector3 targetPos = player.position + new Vector3(0.5f, 0.5f, 0);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
    }

    public void ActivateSkill()
    {
        if (data.mountSkill != null)
        {
            Instantiate(data.mountSkill.skillPrefab, transform.position, Quaternion.identity);
        }
    }
}
