using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] Points;

    private void Awake()
    {
        Debug.Log("Awake - define Points collection");

        // Clear any existing waypoints
        Points = new Transform[transform.childCount];

        for (var index = 0; index < transform.childCount; index++)
        {
            Points[index] = transform.GetChild(index);
        }
    }
}
