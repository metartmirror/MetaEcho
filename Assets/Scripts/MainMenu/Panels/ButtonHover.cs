using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    private Image _hoverImage;
    [Tooltip("Target alpha value when input is empty. Range: 0 to 255")]
    public float emptyInputAlpha = 150f; // Default value 150, can be changed in the editor

    [Tooltip("Duration of the fade effect in seconds")]
    public float fadeDuration = 0.5f; // Default fade duration, can be changed in the editor

    private bool _lastOn;
    private void Awake()
    {
        _hoverImage = GetComponent<Image>();
    }

    public void SetButtonHover(bool on)
    {
        if(_lastOn == on) return;
        _hoverImage.DOFade(on ? emptyInputAlpha / 255f : 0f / 255f, fadeDuration);
        _hoverImage.raycastTarget = on;
        _lastOn = on;
    }
}
