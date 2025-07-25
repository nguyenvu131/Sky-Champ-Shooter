using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZigzagMove : MonoBehaviour {

	public float moveAmount = 2f;
    public float moveTime = 1f;
    public float speed = 1.5f;

    void Start()
    {
        transform.DOMoveX(transform.position.x + moveAmount, moveTime)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
