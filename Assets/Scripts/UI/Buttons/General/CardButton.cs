using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnButtonLeftClick;
    public UnityEvent OnButtonRightClick;
    public UnityEvent OnButtonHover;
    private bool onHover;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnButtonLeftClick.Invoke();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnButtonRightClick.Invoke();
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        onHover = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        onHover = false;
    }

    private void OnEnable()
    {
        onHover = false;
    }
    private void Update()
    {
        if (onHover)
        {
            OnButtonHover.Invoke();
        }
    }
}
