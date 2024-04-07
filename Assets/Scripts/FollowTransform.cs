using Sirenix.OdinInspector;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform target; // Assign this in the inspector with the object to follow
    public Vector3 positionOffset; // Offset from the target's position
    public float rotationOffset; // Offset from the target's rotation

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    
    [Button]
    private void Follow()
    {
        // Follow the X and Z position of the target
        transform.position = new Vector3(target.position.x + positionOffset.x, transform.position.y, target.position.z + positionOffset.z);
        
        // Follow the Y rotation of the target
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, target.rotation.eulerAngles.y + rotationOffset, transform.rotation.eulerAngles.z);
    }
}