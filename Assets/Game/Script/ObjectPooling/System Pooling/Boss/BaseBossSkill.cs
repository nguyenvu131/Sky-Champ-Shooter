using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBossSkill : MonoBehaviour, IBossSkill
{
    public virtual void Activate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
