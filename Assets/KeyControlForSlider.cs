using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class KeyControlForSlider : MonoBehaviour
{
    public Slider volumeSlider; // Assign your UI Slider in the Inspector
    public float adjustSpeed = 1.0f; // The speed at which the slider adjusts

    void Update()
    {
        // Get the right hand controller's device
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithRole(InputDeviceRole.RightHanded, rightHandDevices);

        if (rightHandDevices.Count > 0)
        {
            var rightHandController = rightHandDevices[0]; // Assuming there's at least one right hand device

            // Check if the device is valid and attempt to get the joystick / touchpad axis value
            if (rightHandController.isValid && 
                rightHandController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickValue))
            {
                // Use the y-axis of the joystick to adjust the slider value
                volumeSlider.value += joystickValue.y * adjustSpeed * Time.deltaTime;

                // Clamp the slider value to ensure it doesn't go out of bounds
                volumeSlider.value = Mathf.Clamp(volumeSlider.value, volumeSlider.minValue, volumeSlider.maxValue);
            }
        }
    }
}