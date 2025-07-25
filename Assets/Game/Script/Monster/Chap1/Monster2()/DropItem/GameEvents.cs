using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	public static GameEvents Instance;

	private List<IEnemyDeathListener> deathListeners = new List<IEnemyDeathListener>();

	void Awake() {
		
//		Instance = this;
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void RegisterEnemyDeathListener(IEnemyDeathListener listener)
	{
		if (!deathListeners.Contains(listener))
			deathListeners.Add(listener);
	}

	public void UnregisterEnemyDeathListener(IEnemyDeathListener listener)
	{
		if (deathListeners.Contains(listener))
			deathListeners.Remove(listener);
	}

	public void NotifyEnemyDeath(Monster enemy)
	{
		foreach (var listener in deathListeners)
			listener.OnEnemyDeath(enemy);
	}
}
