using System;
using KevinCastejon.ConeMesh;
using UnityEngine;

public class DirectionalMicrophone : MonoBehaviour
{
    public static DirectionalMicrophone Instance { get; private set; } // 单例模式

    public float clearRangeAngle = 25f; // 清晰听到声音的角度范围
    public float listenableRangeAngle = 45f; // 可听到声音的角度范围
    public float maxCutoffFrequency = 22000f; // 最大截止频率
    public float minCutoffFrequency = 500f; // 最小截止频率
    
    public Cone visualizedCone; // 可视化的话筒锥形

    void Awake()
    {
        // 单例模式确保只有一个话筒实例
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        visualizedCone.ConeRadius = Mathf.Deg2Rad * clearRangeAngle;
    }

    private void OnValidate()
    {
        visualizedCone.ConeRadius = Mathf.Deg2Rad * clearRangeAngle;
    }
}