using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems; // Required for detecting selection and hover

public class PointerButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject pointerSubObject; // Assign your Pointer subobject in the inspector
    public FadeSlideIn pointerLeft;
    public FadeSlideIn pointerRight;
    
    public float moveDuration = 0.2f; // Duration of the move animation
    public Ease moveEase = Ease.OutQuad;
    public float fadeDuration = 0.2f; // Duration of the fade animation
    public Ease fadeEase = Ease.OutQuad;

    private void Awake()
    {
        if (pointerSubObject == null)
        {
            Debug.LogError("Pointer Subobject is not assigned!");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerSubObject.SetActive(true); // Enable the pointer subobject
        pointerLeft.canvasGroup.alpha = 1;
        pointerRight.canvasGroup.alpha = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerSubObject.SetActive(false); // Disable the pointer subobject
    }

    public void OnSelect(BaseEventData eventData)
    {
        pointerSubObject.SetActive(true); // Also enable the pointer subobject when selected
    }

    public void OnDeselect(BaseEventData eventData)
    {
        pointerSubObject.SetActive(false); // Disable the pointer subobject when deselected
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Move pointers towards the center
        pointerLeft.transform.DOLocalMoveX(0, moveDuration).SetEase(moveEase);
        pointerRight.transform.DOLocalMoveX(0, moveDuration).SetEase(moveEase);
        pointerLeft.canvasGroup.DOFade(0, fadeDuration).SetEase(fadeEase);
        pointerRight.canvasGroup.DOFade(0, fadeDuration).SetEase(fadeEase);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        // Move pointers back to their original positions
        pointerLeft.transform.DOLocalMove(pointerLeft.finalPosition, moveDuration).SetEase(moveEase);
        pointerRight.transform.DOLocalMove(pointerRight.finalPosition, moveDuration).SetEase(moveEase);
        pointerLeft.canvasGroup.DOFade(1, fadeDuration).SetEase(fadeEase);
        pointerRight.canvasGroup.DOFade(1, fadeDuration).SetEase(fadeEase);
    }
}