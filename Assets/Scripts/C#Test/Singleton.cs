using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// µ¥ÀýÀà
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : class,new()
{
    static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
}
