using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    //�����ⲿset instance
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
