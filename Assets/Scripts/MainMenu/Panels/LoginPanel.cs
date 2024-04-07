using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    public static LoginPanel instance;

    public CanvasGroup connectingMessage, roomPanel;
    public Transform playerSlotParent;

    private void Awake()
    {
        instance = this;
    }

    public bool MainPanelRightUpEnable {
        set => SetPanelEnable(connectingMessage, value);
    }
    
    public bool RoomPanelEnable {
        set => SetPanelEnable(roomPanel, value);
    }

    private void SetPanelEnable(CanvasGroup panel, bool enable)
    {
        var targetAlpha = enable ? 1f : 0f;
        var interactableAndBlocksRaycasts = enable;
        
        panel.DOFade(targetAlpha, 0.5f) // 0.5f is the duration of the fade
            .OnComplete(() => {
                panel.interactable = interactableAndBlocksRaycasts;
                panel.blocksRaycasts = interactableAndBlocksRaycasts;
            });
    }
}
