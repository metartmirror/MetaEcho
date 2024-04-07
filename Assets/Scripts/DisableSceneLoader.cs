using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSceneLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneLoader.Instance.loadingScreen.SetActive(false);
    }
}
