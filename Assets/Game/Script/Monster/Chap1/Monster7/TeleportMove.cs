using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleportMove : MonoBehaviour {

	public Vector3[] points;
    public float interval = 2f;

    private int current = 0;

    void Start()
    {
        InvokeRepeating("TeleportNext", 0f, interval);
    }

    void TeleportNext()
    {
        if (points.Length == 0) return;

        transform.DOMove(points[current], 0.5f).SetEase(Ease.Flash);
        current = (current + 1) % points.Length;
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
