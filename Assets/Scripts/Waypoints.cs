﻿using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] Points;

    // Awake is called before Start method
    private void Awake()
    {
        // Clear any existing waypoints
        Points = new Transform[transform.childCount];

        for (var index = 0; index < transform.childCount; index++)
        {
            Points[index] = transform.GetChild(index);
        }
    }
}
