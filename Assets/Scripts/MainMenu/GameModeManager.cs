using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    private static GameModeManager instance;

    public static GameModeManager Instance
    {
        get
        {
            if (instance == null)
            {
                // 在场景中查找实例
                instance = FindObjectOfType<GameModeManager>();
                if (instance == null)
                {
                    // 如果没有找到，创建一个新的游戏对象
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameModeManager).Name;
                    instance = obj.AddComponent<GameModeManager>();
                }
            }
            return instance;
        }
    }
    
    public List<GameMode> modes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 确保单例不被销毁
        }
        else
        {
            if (this != instance)
            {
                Destroy(gameObject); // 销毁重复的实例
            }
        }
    }


    public GameMode GetGameModeByID(int ID)
    {
        return modes.Where(c => c.ClassID == ID).ToList()[0];
    }
}
