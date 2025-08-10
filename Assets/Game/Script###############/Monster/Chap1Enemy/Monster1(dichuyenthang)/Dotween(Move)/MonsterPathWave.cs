using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterPathWave : MonoBehaviour
{
    public int waveCount = 3;
    public float waveWidth = 5f;
    public float waveHeight = 2f;
    public float duration = 5f;

    void Start()
    {
        List<Vector3> wavePath = new List<Vector3>();
        Vector3 start = transform.position;

        for (int i = 0; i <= waveCount; i++)
        {
            float x = start.x + i * waveWidth;
            float y = start.y + (i % 2 == 0 ? waveHeight : -waveHeight);
            wavePath.Add(new Vector3(x, y, start.z));
        }

        transform.DOPath(wavePath.ToArray(), duration, PathType.CatmullRom)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
