using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController  : MonoBehaviour {

	public PlayerStats stats;
    public PlayerStatsUI statsUI;

	 void Start()
    {
        statsUI.UpdateUI(stats);
    }

    void Update()
    {
        // Nếu HP thay đổi theo thời gian:
        statsUI.UpdateUI(stats);
    }
	
}
