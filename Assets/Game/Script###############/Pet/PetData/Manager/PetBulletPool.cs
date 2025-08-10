using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletPool : MonoBehaviour {

	public static PetBulletPool Instance;

    public GameObject basicBulletPrefab;
    public int poolSize = 20;
    private List<GameObject> bullets = new List<GameObject>();

    void Awake() {
        Instance = this;
        for (int i = 0; i < poolSize; i++) {
            GameObject b = Instantiate(basicBulletPrefab);
            b.SetActive(false);
            bullets.Add(b);
        }
    }

    public GameObject GetBullet(PetType type) {
        foreach (var b in bullets) {
            if (!b.activeInHierarchy)
                return b;
        }
        GameObject newB = Instantiate(basicBulletPrefab);
        newB.SetActive(false);
        bullets.Add(newB);
        return newB;
    }
}
