using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Attributes")]
    public float ScrollSpeed = 30f;
    public float PanSpeed = 30f;
    public float PanBorder = 30f;
    public float MinimumZoom = 20f;
    public float MaximumZoom = 90f;

    // Update is called once per frame
    private void Update()
    {
        // Move up with 'W' or by moving mouse to top of screen
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - PanBorder)
        {
            gameObject.transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }

        // Move down with 'S' or by moving mouse to bottom of screen
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= PanBorder)
        {
            gameObject.transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }

        // Move right with 'D' or by moving mouse to right of screen
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - PanBorder)
        {
            gameObject.transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }

        // Move left with 'A' or by moving mouse to left of screen
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= PanBorder)
        {
            gameObject.transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        // Handle Scroll wheel for zooming
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Math.Abs(scroll) > 0.001)
        {
            var position = gameObject.transform.position;

            position.y -= scroll * 100 * ScrollSpeed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, MinimumZoom, MaximumZoom);

            gameObject.transform.position = position;
        }
    }
}
