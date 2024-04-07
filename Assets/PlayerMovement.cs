using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera myCamera;
    
    public float moveDistance = 1.0f; // The distance the player will move per key press
    public float rotationAngle = 45.0f; // The angle the player will rotate per key press

    private bool canMove = true; // Flag to control when the player can move again
    private bool canRotate = true; // Flag to control when the player can rotate again

    void Update()
    {
        // Handle movement
        if (canMove && Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            // Determine the direction based on the axis value
            float moveStep = Input.GetAxis("Vertical") > 0 ? moveDistance : -moveDistance;

            // Move the player
            var forward = myCamera.transform.forward;
            forward.y = 0;
            transform.position += forward * moveStep;
            
            canMove = false; // Disable further movement until the key is released
        }

        // Prevent continuous movement
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.1f)
        {
            canMove = true; // Allow movement again once the key is released
        }

        // Handle rotation
        if (canRotate && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            // Determine the direction based on the axis value
            float rotationStep = Input.GetAxis("Horizontal") > 0 ? rotationAngle : -rotationAngle;

            // Rotate the player
            transform.Rotate(Vector3.up * rotationStep);
            
            canRotate = false; // Disable further rotation until the key is released
        }

        // Prevent continuous rotation
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f)
        {
            canRotate = true; // Allow rotation again once the key is released
        }
    }
}
