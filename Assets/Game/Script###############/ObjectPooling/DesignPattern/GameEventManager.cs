using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager
{
    private static GameEventManager _instance;
	
    public static GameEventManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameEventManager();
            return _instance;
        }
    }

    private Dictionary<string, List<IGameEventListener>> listeners = new Dictionary<string, List<IGameEventListener>>();

    public void Subscribe(string eventName, IGameEventListener listener)
    {
        if (!listeners.ContainsKey(eventName))
            listeners[eventName] = new List<IGameEventListener>();

        if (!listeners[eventName].Contains(listener))
            listeners[eventName].Add(listener);
    }

    public void Unsubscribe(string eventName, IGameEventListener listener)
    {
        if (listeners.ContainsKey(eventName))
            listeners[eventName].Remove(listener);
    }

    public void RaiseEvent(string eventName, object eventData = null)
    {
        if (listeners.ContainsKey(eventName))
        {
            foreach (var listener in listeners[eventName])
                listener.OnEventRaised(eventName, eventData);
        }
    }
}
