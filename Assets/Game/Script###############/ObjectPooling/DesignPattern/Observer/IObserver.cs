using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void OnNotify(string eventName, object param = null);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers(string eventName, object param = null);
}
