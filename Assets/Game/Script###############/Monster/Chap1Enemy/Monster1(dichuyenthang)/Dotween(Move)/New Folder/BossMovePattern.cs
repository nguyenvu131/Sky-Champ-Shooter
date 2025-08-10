using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossMovePattern : MonoBehaviour {

	public Transform[] waypoints; // Các điểm đến theo thứ tự
    public float moveSpeed = 2f;
    public float waitTime = 1f;

    private Sequence moveSequence;

    void OnEnable()
    {
        StartPattern();
    }

    void StartPattern()
    {
        moveSequence = DOTween.Sequence();

        for (int i = 0; i < waypoints.Length; i++)
        {
            moveSequence.Append(transform.DOMove(waypoints[i].position, moveSpeed).SetEase(Ease.InOutSine));
            moveSequence.AppendInterval(waitTime);
        }

        moveSequence.SetLoops(-1); // Lặp vô hạn nếu cần
    }

    void OnDisable()
    {
        moveSequence.Kill();
    }
}
