using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterPathLinear : MonoBehaviour
{
    public Transform[] pathPoints; // Đặt các điểm trong Inspector
    public float moveDuration = 5f;

    void Start()
    {
        Vector3[] path = new Vector3[pathPoints.Length];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            path[i] = pathPoints[i].position;
        }

        transform.DOPath(path, moveDuration, PathType.Linear)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo); // Di chuyển qua lại liên tục
    }
}
