using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例类
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    //避免外部set instance
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this.gameObject.GetComponent<T>();
        OnStart();
    }

    virtual
    protected void OnStart()
    {

    }
}
