using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentScore = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        Debug.Log("Score: " + CurrentScore);
    }
}
