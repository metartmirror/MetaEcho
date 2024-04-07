using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public Transform head;
    public Animator headAnimator;
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    
    public bool enableAnimation;


    private bool EnableAnimation
    {
        get => enableAnimation;
        set
        {
            enableAnimation = value;
            headAnimator.enabled = value;
            leftHandAnimator.enabled = value;
            rightHandAnimator.enabled = value;
        }
    }
    
    private void Update()
    {
        EnableAnimation = enableAnimation;
    }
}
