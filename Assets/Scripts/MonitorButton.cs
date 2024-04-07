using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class MonitorButton : MonoBehaviourPun
{
    public RawImage monitorImage;
    public Texture monitorTexture;

    private void OnValidate()
    {
        if (monitorTexture == null) return;
        monitorImage.texture = monitorTexture;
    }
    
    public void SetMonitorTexture()
    {
        //WavingBall.Instance.cameraImage.texture = monitorTexture;
        photonView.RPC("SetMonitorTextureRPC", RpcTarget.AllBuffered);
    }
    
    // 使用 [PunRPC] 标记该函数作为 RPC 函数
    [PunRPC]
    public void SetMonitorTextureRPC()
    {
        // 设置监视器纹理
        WavingBall.Instance.cameraImage.texture = monitorTexture;
    }
}
