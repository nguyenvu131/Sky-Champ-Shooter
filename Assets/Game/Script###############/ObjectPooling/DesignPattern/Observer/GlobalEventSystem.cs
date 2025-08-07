using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventSystem : MonoBehaviour, ISubject
{
    public static GlobalEventSystem Instance;

    private List<IObserver> observers = new List<IObserver>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void NotifyObservers(string eventName, object param = null)
    {
        foreach (var obs in observers)
        {
            obs.OnNotify(eventName, param);
        }
    }
}
