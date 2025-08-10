using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoldManager : MonoBehaviour
{
    public static PlayerGoldManager Instance;
    public int currentGold = 1000;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            return true;
        }
        return false;
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
    }
}
