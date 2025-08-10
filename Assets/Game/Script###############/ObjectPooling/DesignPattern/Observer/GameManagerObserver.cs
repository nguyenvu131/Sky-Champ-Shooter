using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObserver : MonoBehaviour {

	public GameEventManagerObserver eventManager;
    public UIHealthBar uiHP;

    void Start()
    {
        eventManager = new GameEventManagerObserver();
        eventManager.RegisterObserver(uiHP);
    }

    public void PlayerTakesDamage(int amount)
    {
        // Giả lập thay đổi HP
        int currentHP = 100 - amount;
        eventManager.NotifyObservers("PLAYER_HP_CHANGED", currentHP);
    }
}
