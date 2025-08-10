using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleMove : MonoBehaviour {

	public float radius = 2f;
    public float duration = 2f;

    void Start()
    {
        Vector3 center = transform.position;

        Sequence seq = DOTween.Sequence();
        for (int i = 0; i <= 360; i += 30)
        {
            float rad = Mathf.Deg2Rad * i;
            Vector3 point = center + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * radius;
            seq.Append(transform.DOMove(point, duration / 12f).SetEase(Ease.Linear));
        }
        seq.SetLoops(-1);
    }
}
