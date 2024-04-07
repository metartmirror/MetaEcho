using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.XR.CoreUtils; // 引用TextMeshPro命名空间

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen; // 指向加载界面的Panel
    public Image progressBar; // 进度条
    public TextMeshProUGUI loadingText; // 加载提示文本
    public XROrigin XROrigin; // 需要在加载场景时禁用的对象
    public Camera myCamera;
    
    public static SceneLoader Instance { get; private set; }
    
    private void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //dont destroy on load
        DontDestroyOnLoad(gameObject);
    }

    // 调用这个方法来加载新场景
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; 
        
        loadingScreen.SetActive(true); // 显示加载界面
        XROrigin.Camera = myCamera;

        while (!operation.isDone)
        {
            // 直到进度至少为0.9时才继续
            if (operation.progress >= 0.9f)
            {
                // 显示加载完毕，准备切换的提示
                loadingText.text = "Press any button to continue...";
                progressBar.fillAmount = 1f;

                // 检查用户是否按下任何按钮来激活场景
                if (Input.anyKeyDown) // 你可以根据实际情况调整这里的条件
                {
                    operation.allowSceneActivation = true;
                }
            }
            else
            {
                // 平滑进度条
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                progressBar.fillAmount = progress;
                loadingText.text = (progress * 100f).ToString("F2") + "%";
            }

            yield return null;
        }
    }
}