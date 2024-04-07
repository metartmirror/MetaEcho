using UnityEngine;
using UnityEngine.UI; // Required for accessing the Slider component
using UnityEngine.Audio; // Required for accessing the AudioMixer

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer; // Assign this in the inspector with your MainMixer
    public Slider volumeSlider; // Assign this in the inspector with your UI slider

    private void Start()
    {
        // Optional: Initialize slider's value to represent current volume setting
        float currentVolume;
        if (audioMixer.GetFloat("MasterVolume", out currentVolume))
        {
            volumeSlider.value = MapVolumeToSliderValue(currentVolume);
        }

        // Add listener for when the slider value changes
        volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float sliderValue)
    {
        // Map the slider value (0 to 5) to the mixer volume (-60 to 12)
        float mixerVolume = MapSliderValueToVolume(sliderValue);
        audioMixer.SetFloat("MasterVolume", mixerVolume);
    }

    private float MapSliderValueToVolume(float sliderValue)
    {
        // Maps the slider value from 0-5 to a volume level from -60 to 12
        return Mathf.Lerp(-60, 12, sliderValue / 5f);
    }

    private float MapVolumeToSliderValue(float volume)
    {
        // Maps the volume level from -60-12 to a slider value of 0-5
        return ((volume + 60) / 72) * 5;
    }
}