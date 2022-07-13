using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//TODO: ÕÍ…∆ ±÷”

public class Clock : MonoBehaviour
{
    public static Clock instance;

    public UnityEvent<int> unityEvent;
    public UnityAction<int> action;

    // Start is called before the first frame update
    void Awake()
    {
        action = new UnityAction<int>(Call);
        instance = this;
        unityEvent = new UnityEvent<int>();
    }

    private void Call(int entity)
    {
        if(entity == (entity | (int)Entity.Hostess))
        {
            
        }
    }

    public void Onsss()
    {
        Clock.instance.unityEvent.Invoke((int)Entity.Clock);
    }
}
