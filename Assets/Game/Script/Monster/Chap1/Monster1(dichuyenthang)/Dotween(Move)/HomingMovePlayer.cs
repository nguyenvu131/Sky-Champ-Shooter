using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMovePlayer : MonoBehaviour {

	public float speed = 2f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
