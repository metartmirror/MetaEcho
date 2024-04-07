using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StickRotater : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Degrees per second

    private void Update()
    {
        // Get the right controller
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithRole(InputDeviceRole.RightHanded, rightHandDevices);

        if (rightHandDevices.Count > 0)
        {
            var rightHandController = rightHandDevices[0];

            // Check if the right controller's A button is pressed
            if (rightHandController.isValid &&
                rightHandController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton) && 
                primaryButton)
            {
                // Rotate left around the Y axis at the specified speed
                transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
            }

            // Check if the right controller's B button is pressed
            if (rightHandController.isValid &&
                rightHandController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton) && 
                secondaryButton)
            {
                // Rotate right around the Y axis at the specified speed
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
        }
    }
}