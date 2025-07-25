using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemMonster1 : MonoBehaviour
{
    public string itemID;
    public float pickUpRadius = 1.5f;
    private Transform player;

    void OnEnable()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) < pickUpRadius)
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        // TODO: thêm vào inventory nếu có
        Debug.Log("Picked up: " + itemID);

        DropItemPoolManager.Instance.ReturnToPool(gameObject);
    }
}
