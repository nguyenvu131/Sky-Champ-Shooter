using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterPathCircle : MonoBehaviour
{
    public int points = 36;
    public float radius = 5f;
    public float duration = 6f;

    void Start()
    {
        List<Vector3> circlePath = new List<Vector3>();

        for (int i = 0; i < points; i++)
        {
            float angle = i * Mathf.PI * 2f / points;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            circlePath.Add(transform.position + new Vector3(x, y, 0));
        }

        transform.DOPath(circlePath.ToArray(), duration, PathType.Linear)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
}
