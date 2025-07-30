using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUIFollow : MonoBehaviour
{
    public Transform target; // Monster Transform
    public Vector3 offset = new Vector3(0, 2f, 0); // lệch lên đầu

    private RectTransform rectTransform;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (target == null || cam == null) return;

        Vector3 worldPos = target.position + offset;
        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);

        rectTransform.position = screenPos;
    }
}
