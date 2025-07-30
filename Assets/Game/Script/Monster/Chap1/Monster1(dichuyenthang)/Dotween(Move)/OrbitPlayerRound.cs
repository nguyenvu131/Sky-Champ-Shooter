using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayerRound : MonoBehaviour {

	public float orbitRadius = 3f;
    public float orbitSpeed = 90f; // degree/sec
    private Transform player;
    private float angle;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        angle = Random.Range(0, 360f);
    }

    void Update()
    {
        if (player == null) return;

        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;
        transform.position = player.position + offset;
    }
}
