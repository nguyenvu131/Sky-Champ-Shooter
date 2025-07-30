using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveZigZag : MonoBehaviour {

	public float horizontalAmount = 2f;
    public float horizontalTime = 1.5f;
    public float verticalSpeed = 1.5f;

    void Start()
    {
        // Zigzag ngang
        transform.DOMoveX(transform.position.x + horizontalAmount, horizontalTime)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    void Update()
    {
        // Rơi xuống từ từ
        transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
    }
}
