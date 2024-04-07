using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public AudioSource audioSource; // The original, spatial 3D AudioSource
    private AudioSource analysisAudioSource; // The additional AudioSource for analysis
    public GameObject visualizedObject; // Object to scale based on audio loudness
    public float updateStep = 0.1f; // Time between updates in seconds
    public int sampleDataLength = 1024; // Length of the sample data array
    public Vector3 minScale = Vector3.zero; // Minimum scale of the visualized object
    public float scaleMultiplier = 10; // Scale multiplier for the visualized object
    public bool analyzeSpectrum = false; // Analyze spectrum instead of waveform

    private float currentUpdateTime = 0f;
    private float clipLoudness;
    private float[] clipSampleData;

    private float volume = 0.01f;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];

        // Create the additional AudioSource for analysis
        if (!analyzeSpectrum)
        {
            analysisAudioSource = gameObject.AddComponent<AudioSource>();
            analysisAudioSource.clip = audioSource.clip;
            analysisAudioSource.playOnAwake = audioSource.playOnAwake;
            analysisAudioSource.loop = audioSource.loop;
            analysisAudioSource.spatialBlend = 0; // Set to 2D sound
            analysisAudioSource.volume = volume; // Ensure it's silent
            analysisAudioSource.Play();
        }else
        {
            analysisAudioSource = audioSource;
            volume = 1;
        }
    }

    private void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            analysisAudioSource.GetOutputData(clipSampleData, 0);
            // Calculate loudness
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; // Average loudness
            // Use clipLoudness to scale the visualized object
            visualizedObject.transform.localScale = minScale + new Vector3(1, 1, 1) * (clipLoudness * scaleMultiplier) / volume; // Example scaling factor
        }
    }
}
