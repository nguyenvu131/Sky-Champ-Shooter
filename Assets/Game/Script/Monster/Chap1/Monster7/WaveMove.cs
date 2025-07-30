using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class WaveMove : MonoBehaviour
{
    public float moveDistance = 2f; // khoảng cách trái phải
    public float moveDuration = 1.5f; // thời gian cho mỗi lần lắc

    void Start()
    {
        // Di chuyển qua lại theo trục X
        transform.DOMoveX(transform.position.x + moveDistance, moveDuration)
            .SetLoops(-1, LoopType.Yoyo) // Lặp vô hạn kiểu tới lui
            .SetEase(Ease.InOutSine);
    }
}
