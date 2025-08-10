using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSatellite : MonoBehaviour {

	public Transform core;
    public float speed = 1f;
    public float radius = 1.5f;
    public float angle;

    void Update()
    {
        if (core == null) return;

        angle += speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        transform.position = core.position + offset;
    }

    void OnDestroy()
    {
        // Có thể thêm hiệu ứng nổ vệ tinh ở đây
    }
}
