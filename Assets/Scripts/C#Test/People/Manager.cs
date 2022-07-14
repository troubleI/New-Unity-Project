using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Manager : MonoBehaviour
{
    protected List<Creature> creatures;

    public GameObject prefab;

    protected UnityAction<int> action;

    protected int entityNum;

    protected void Start()
    {
        creatures = new List<Creature>();
        action = new UnityAction<int>(Call);
        Init();
        CreateCreature();
    }

    //这里创建GameObject，因为没有具体业务，所以暂时比较简陋
    abstract
    protected void CreateCreature();

    //事件回调会先匹配是否有因素会影响到自己，影响的话执行动作
    public void Call(int entity)
    {
        if (creatures.Count == 0 || entityNum == entity)
            return;
        entityNum = entity;
        int beforeEntity = entity;
        foreach (Creature creature in creatures)
        {
            entity |= (int)creature.Notice(entity);
        }
        //若产生影响就取消订阅，否则会被重复影响
        if (beforeEntity != entity)
            Remove();
        Clock.Instance.unityEvent.Invoke(entity);
    }

    public void Init()
    {
        entityNum = 0;
        Clock.Instance.unityEvent.AddListener(action);
    }

    private void Remove()
    {
        Clock.Instance.unityEvent.RemoveListener(action);
    }
}
