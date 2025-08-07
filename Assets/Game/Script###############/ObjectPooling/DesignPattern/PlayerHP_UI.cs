using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHP_UI : MonoBehaviour, IGameEventListener
{
    public Slider hpSlider;

    void OnEnable()
    {
        GameEventManager.Instance.Subscribe("PLAYER_TAKE_DAMAGE", this);
    }

    void OnDisable()
    {
        GameEventManager.Instance.Unsubscribe("PLAYER_TAKE_DAMAGE", this);
    }

    public void OnEventRaised(string eventName, object eventData)
    {
        if (eventName == "PLAYER_TAKE_DAMAGE")
        {
            int newHP = (int)eventData;
            hpSlider.value = newHP;
        }
    }
}
