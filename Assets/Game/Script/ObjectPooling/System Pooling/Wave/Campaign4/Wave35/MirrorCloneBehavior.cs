using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCloneBehavior : MonoBehaviour {

	public bool isMainClone = false;
    public int maxSplits = 1;
    public float splitDelay = 3f;
    public GameObject clonePrefab;

    private bool hasSplit = false;

    void Start()
    {
        if (isMainClone)
            Invoke("SplitIntoClones", splitDelay);
    }

    void Update()
    {
        transform.position += Vector3.down * 1.5f * Time.deltaTime;
        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void SplitIntoClones()
    {
        if (hasSplit || maxSplits <= 0) return;
        hasSplit = true;

        for (int i = 0; i < 2; i++)
        {
            Vector3 offset = new Vector3(i == 0 ? -0.5f : 0.5f, 0, 0);
            GameObject clone = Instantiate(gameObject, transform.position + offset, Quaternion.identity, transform.parent);

            MirrorCloneBehavior cloneBehavior = clone.GetComponent<MirrorCloneBehavior>();
            cloneBehavior.isMainClone = false;
            cloneBehavior.maxSplits = 0;
        }
    }
}
