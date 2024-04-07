using UnityEngine;
using UnityEngine.EventSystems; // Required for detecting hover
using DG.Tweening; // Required for DOTween animations

public class EnlargeButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float hoverScale = 1.1f; // Scale factor when hovered
    public float clickScale = 0.9f; // Scale factor when clicked
    public float animationDuration = 0.2f; // Duration of the scale animation
    public Ease animationEase = Ease.OutQuad; // Type of easing for the animation

    private Vector3 originalScale; // To store the original scale of the button

    private void Awake()
    {
        originalScale = transform.localScale; // Store the original scale of the button
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimateScale(hoverScale); // Scale up
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AnimateScale(1); // Scale back to original
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        AnimateScale(clickScale); // Scale down
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        AnimateScale(hoverScale); // Scale up
    }

    private void AnimateScale(float targetScale)
    {
        transform.DOScale(originalScale * targetScale, animationDuration).SetEase(animationEase);
    }
}