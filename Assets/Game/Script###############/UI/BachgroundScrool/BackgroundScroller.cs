using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed = 0.1f;
    private Material mat;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && sr.material != null)
            mat = sr.material;
    }

    void Update()
    {
        if (mat != null)
        {
            Vector2 offset = mat.mainTextureOffset;
            offset.y += scrollSpeed * Time.deltaTime;
            mat.mainTextureOffset = offset;
        }
    }
}
