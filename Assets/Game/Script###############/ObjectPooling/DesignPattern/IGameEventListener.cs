using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListener
{
    void OnEventRaised(string eventName, object eventData = null);
}
