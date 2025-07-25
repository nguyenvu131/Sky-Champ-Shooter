using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SinTweenWave : MonoBehaviour {

	public float sinAmplitude = 1f;
    public float sinFrequency = 2f;
    public float tweenDistance = 3f;
    public float tweenDuration = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // Tween dọc xuống chậm
        transform.DOMoveY(transform.position.y - tweenDistance, tweenDuration)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }

    void Update()
    {
        float x = startPos.x + Mathf.Sin(Time.time * sinFrequency) * sinAmplitude;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
