using UnityEngine;
using UnityEngine.EventSystems; // Required for UI interaction events

[RequireComponent(typeof(AudioSource))] // Ensure there's an AudioSource component
public class ButtonSoundEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public AudioClip enterClip;
    public AudioClip exitClip;
    public AudioClip clickDownClip;
    public AudioClip clickUpClip;

    private AudioSource audioSource;

    private void Awake()
    {
        // Get the AudioSource component, add one if not already attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySound(enterClip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlaySound(exitClip);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlaySound(clickDownClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlaySound(clickUpClip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Optional: Implement your method or coroutine to handle continuous hover sound effect, if required.
}