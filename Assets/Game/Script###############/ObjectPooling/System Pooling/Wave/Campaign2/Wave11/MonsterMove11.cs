using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove11 : MonoBehaviour {

	public float moveSpeed = 2f;
    public float speedBoost = 4f;
    public float boostDistance = 4f;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);
        float speed = (dist < boostDistance) ? speedBoost : moveSpeed;

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
