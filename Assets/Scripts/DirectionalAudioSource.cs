using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(AudioLowPassFilter))]
public class DirectionalAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioLowPassFilter lowPassFilter;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
    }

    void Update()
    {
        if (DirectionalMicrophone.Instance == null) return;

        Transform microphoneTransform = DirectionalMicrophone.Instance.transform;
        float clearRangeAngle = DirectionalMicrophone.Instance.clearRangeAngle;
        float maxCutoffFrequency = DirectionalMicrophone.Instance.maxCutoffFrequency;
        float minCutoffFrequency = DirectionalMicrophone.Instance.minCutoffFrequency;

        // 计算声源方向和话筒前方向之间的角度
        Vector3 directionToSource = (transform.position - microphoneTransform.position).normalized;
        float angle = Vector3.Angle(microphoneTransform.up, directionToSource);

        // 根据角度调整音量和低通滤波器
        if (angle <= clearRangeAngle)
        {
            audioSource.volume = 1.0f;
            lowPassFilter.cutoffFrequency = maxCutoffFrequency;
        }
        else
        {
            float volumeDecrease = Mathf.InverseLerp(clearRangeAngle, clearRangeAngle+20, angle);
            audioSource.volume = 1.0f - volumeDecrease;
            lowPassFilter.cutoffFrequency = Mathf.Lerp(maxCutoffFrequency, minCutoffFrequency, volumeDecrease);
            //print("Adjust Volume and LowPassFilter: " + audioSource.volume + " " + lowPassFilter.cutoffFrequency);
        }
    }
}