using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WavingBall : MonoBehaviour
{
    public AudioSource mainAudioSource;
    public Vector3 offset;
    public Canvas canvas;
    public RawImage cameraImage;
    public Texture[] cameraTexture;
    public Renderer ballRenderer;
    private Material _myMaterial;
    private static readonly int SoundSwitch = Shader.PropertyToID("_SoundSwitch");
    private int _currentTextureID;
    public static WavingBall Instance { get; private set; }

    private void Awake()
    {
        _myMaterial = ballRenderer.material;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    private void Update()
    {

        if (canvas.worldCamera == null)
        {
            var mainCam = Camera.main;
            if (mainCam != null)
                canvas.worldCamera = mainCam;
            
            return;
        }

        // ChangeTexture();
        
        transform.LookAt(canvas.worldCamera.transform);
        
        _myMaterial.SetFloat(SoundSwitch, mainAudioSource.volume);

        if (PlayerCanvas.Instance == null) return;

        transform.position = PlayerCanvas.Instance.transform.position + offset;
    }
    
    private void ChangeTexture()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        _currentTextureID++;
        if(_currentTextureID == cameraTexture.Length)
            _currentTextureID = 0;
        cameraImage.texture = cameraTexture[_currentTextureID];
    }
}
