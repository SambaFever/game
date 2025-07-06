using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    private Camera cam; // Reference to the main camera

    void Start()
    {
        // Get the main camera at the start
        cam = Camera.main;
    }

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) // 0 is for left mouse click
        {
            MoveObjectToMouse();
        }
    }

    // Method to move the object to the mouse position
    void MoveObjectToMouse()
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits any collider
        if (Physics.Raycast(ray, out hit))
        {
            // If the ray hits something, move this object to the hit point
            transform.position = hit.point;
        }
    }
}
