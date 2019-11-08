using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Code referenced: https://learn.unity.com/tutorial/camera-control?projectId=5c5149c5edbc2a001fd5be95#5c7f8528edbc2a002053b398



    public float dampTime = 0.2f; // The time for the camera to refocus
    public float screenEdgeBuffer = 2f; // Buffer so the targets are never at the edge of the screen
    public float minSize; // The minimum size the camera fustrum can be
    public Transform[] targets; // All the targets the camera is looking at

    private Camera camera;
    private float zoomSpeed; // Speed for the smoothing of the cameras zoom
    private Vector3 moveVelocity; // Velocity to smooth the movement of the camera rigs position in the world
    private Vector3 desiredPosition; // The position inbetween all the targets the camera is trying to reach

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate() // Moving player based on fixed update so camera should also move at the same timestep
    {
        Move();
        Zoom();
        Rotate();
    }

    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);

    }

    private void Rotate()
    {
        
        if (Input.GetKey("e"))
        {
            Camera.main.transform.RotateAround(desiredPosition, Vector3.up, 50 * Time.deltaTime);
        }
        else if (Input.GetKey("q"))
        {
            Camera.main.transform.RotateAround(desiredPosition, Vector3.up, -50 * Time.deltaTime);

        }
    }

    private void FindAveragePosition() //Average of all target objects in the scene
    {
        Vector3 totalPos = new Vector3(); // The total position of all the targets
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < targets.Length; i++)
        {
            totalPos += targets[i].position;
            numTargets++;
        }

        if (numTargets > 0) // If we've found targets find the average of all their postions
        {
            averagePos = totalPos / numTargets;

            averagePos.y = transform.position.y; // Keep the same y value

            desiredPosition = averagePos;
        }
    }

    private void Zoom()
    {
        // Find the required fustrum size based on the targets positions and smoothly transition to that size
        float requiredSize = FindRequiredSize();
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);


    }

    private float FindRequiredSize()
    {
        // Find the position the camera rig is moving towards in its local space
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPosition);

        // Start the camera's size calculation at zero
        float size = 0f;

        for (int i = 0; i < targets.Length; i++)
        {
            //find the position of the target in the camera's local space.
            Vector3 targetLocalpos = transform.InverseTransformPoint(targets[i].position);

            // Find the position of the target from the desired position of the camera's local space
            Vector3 desiredPosToTarget = targetLocalpos - desiredLocalPos;

            // Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera.
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            // Choose the largest out of the current size and the calculated size based on the tank being to the left or right of the camera.
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / camera.aspect);
        }

        // Add the edge buffer to the size.
        size += screenEdgeBuffer;

        // Make sure the camera's size isn't below the minimum.
        size = Mathf.Max(size, minSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {
        // Find the desired position.
        FindAveragePosition();

        // Set the camera's position to the desired position without damping.
        transform.position = desiredPosition;

        // Find and set the required size of the camera.
        camera.orthographicSize = FindRequiredSize();
    }
}
