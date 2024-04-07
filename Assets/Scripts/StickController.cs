using UnityEngine;

public class StickController : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;

    void Update()
    {
        if (leftController == null || rightController == null)
            return;

        // Calculate the midpoint between the two controllers
        Vector3 midpoint = (leftController.position + rightController.position) / 2;

        // Set the stick's position to the midpoint
        transform.position = midpoint;

        // Calculate the direction from the left controller to the right controller
        Vector3 targetDirection = rightController.position - leftController.position;

        // Create a rotation that looks in the direction of the targetDirection,
        // but keeps the stick's up direction aligned with the world's up direction.
        // This prevents the stick from flipping as it would with FromToRotation.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Apply the calculated rotation
        transform.rotation = targetRotation;

        // Now the stick's pivot point should be in the center,
        // so we don't need to adjust the position based on the stick's length.
    }
}