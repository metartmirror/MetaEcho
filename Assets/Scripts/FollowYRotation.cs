using UnityEngine;

public class FollowYRotation : MonoBehaviour
{
    // Reference to the target object whose Y rotation we want to follow.
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            // Get the current rotation of the follower and the target.
            Vector3 currentRotation = transform.eulerAngles;
            Vector3 targetRotation = target.eulerAngles;

            // Set the follower's Y rotation to match the target's Y rotation.
            transform.eulerAngles = new Vector3(currentRotation.x, targetRotation.y, currentRotation.z);
        }
    }
}
