using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    public float moveSpeed = 10f;      // Camera movement speed
    public float scrollSpeed = 10f;    // Zoom speed
    public float minZoom = 10f;        // Minimum zoom distance
    public float maxZoom = 50f;        // Maximum zoom distance
    public float rotationSpeed = 100f; // Camera rotation speed
    public float boundaryX = 50f;      // Boundary limit for panning along X axis
    public float boundaryZ = 50f;      // Boundary limit for panning along Z axis

    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Get the camera reference
    }

    void Update()
    {
        MoveCamera();
        ZoomCamera();
        RotateCamera();
    }

    // Function to move the camera
    void MoveCamera()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Moving up/down/left/right based on keyboard input or mouse position
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - 10)
        {
            moveZ = 1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= 10)
        {
            moveZ = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= 10)
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - 10)
        {
            moveX = 1f;
        }

        Vector3 move = new Vector3(moveX, 0f, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Restrict the camera to boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -boundaryX, boundaryX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -boundaryZ, boundaryZ);
        transform.position = clampedPosition;
    }

    // Function to zoom the camera in and out
    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Use scroll wheel to zoom in/out

        if (scroll != 0f)
        {
            cam.fieldOfView -= scroll * scrollSpeed; // Adjust field of view based on scroll
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom); // Clamping zoom to min/max
        }
    }

    // Function to rotate the camera (optional)
    void RotateCamera()
    {
        if (Input.GetMouseButton(1)) // Right mouse button to rotate
        {
            float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotateX, Space.World); // Rotate around the Y-axis
        }
    }
}
