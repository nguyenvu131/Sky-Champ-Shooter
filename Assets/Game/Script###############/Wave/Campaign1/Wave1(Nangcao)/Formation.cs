using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Formation
{
    public string name;
    public List<Vector3> offsets = new List<Vector3>();

    public static Formation VShape()
    {
        Formation f = new Formation();
        f.name = "V";
        f.offsets.Add(new Vector3(0, 0, 0));      // Leader
        f.offsets.Add(new Vector3(-1f, -1f, 0));  // Follower 1
        f.offsets.Add(new Vector3(1f, -1f, 0));   // Follower 2
        f.offsets.Add(new Vector3(-2f, -2f, 0));  // Follower 3
        f.offsets.Add(new Vector3(2f, -2f, 0));   // Follower 4
        return f;
    }

    public static Formation Line()
    {
        Formation f = new Formation();
        f.name = "Line";
        f.offsets.Add(new Vector3(0, 0, 0)); // Leader
        f.offsets.Add(new Vector3(0, -1f, 0));
        f.offsets.Add(new Vector3(0, -2f, 0));
        f.offsets.Add(new Vector3(0, -3f, 0));
        return f;
    }

    public static Formation Circle()
    {
        Formation f = new Formation();
        f.name = "Circle";
        f.offsets.Add(new Vector3(0, 0, 0)); // Leader
        float radius = 1.5f;
        for (int i = 0; i < 6; i++)
        {
            float angle = i * Mathf.PI * 2 / 6;
            f.offsets.Add(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius);
        }
        return f;
    }
}
