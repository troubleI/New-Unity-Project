using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Environment : MonoSingleton<Environment>
{
    public UnityEvent<int> unityEvent;
    protected UnityAction<int> action;

    public Entity myEntity;
    public Entity endEntity;

    protected void Call(int entity)
    {
        if (entity == (entity | (int)endEntity))
        {
            InitAll();
        }
    }

    abstract
    protected void InitAll();

    abstract
    public void Init();

    abstract
    public void Knock();
}
