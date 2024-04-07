using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class OnHoverEnlarge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float enlarge = 1.2f;
    public float enlargeTime = 0.2f;
    Vector3 iniScale, largeScale;

    private void Awake()
    {
        iniScale = transform.localScale;
        largeScale = iniScale * enlarge;
    }
    private void OnEnable()
    {
        transform.localScale = iniScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(largeScale, enlargeTime);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(iniScale, enlargeTime);
    }
}
