using UnityEngine;
using DG.Tweening; // Required for DOTween animations

[RequireComponent(typeof(CanvasGroup))] // Ensure there's a CanvasGroup component
public class FadeSlideIn : MonoBehaviour
{
    public Vector3 startPositionOffset = new Vector3(0, -30, 0); // Start position offset relative to the final position
    public float fadeInDuration = 0.5f; // Duration of the fade-in animation
    public float slideInDuration = 0.5f; // Duration of the slide-in animation
    public Ease fadeInEase = Ease.OutQuad; // Ease type for the fade-in animation
    public Ease slideInEase = Ease.OutQuad; // Ease type for the slide-in animation
    
    public CanvasGroup canvasGroup;
    public Vector3 finalPosition;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        finalPosition = transform.localPosition; // Store the final (current) position
    }

    private void OnEnable()
    {
        StartAnimations();
    }

    private void StartAnimations()
    {
        // Set initial conditions
        canvasGroup.alpha = 0; // Start fully transparent
        transform.localPosition = finalPosition + startPositionOffset; // Start at the offset position
        
        // Start fade-in animation
        canvasGroup.DOFade(1, fadeInDuration).SetEase(fadeInEase);
        
        // Start slide-in animation
        transform.DOLocalMove(finalPosition, slideInDuration).SetEase(slideInEase);
    }
}