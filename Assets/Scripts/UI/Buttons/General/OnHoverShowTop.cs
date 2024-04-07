using UnityEngine.EventSystems;
using UnityEngine;

public class OnHoverShowTop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int topLayer = 2;
    public int lowLayer = 1;
    public Canvas canvas;
    private void OnEnable()
    {
        canvas.sortingOrder = lowLayer;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canvas.sortingOrder = topLayer;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        canvas.sortingOrder = lowLayer;
    }
}
