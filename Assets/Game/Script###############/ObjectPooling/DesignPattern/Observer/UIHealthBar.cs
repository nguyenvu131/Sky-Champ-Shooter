using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour, IObserver
{
    public void OnNotify(string eventName, object param = null)
    {
        if (eventName == "PLAYER_HP_CHANGED")
        {
            int hp = (int)param;
            Debug.Log("Update UI HP: " + hp);
        }
    }
}
