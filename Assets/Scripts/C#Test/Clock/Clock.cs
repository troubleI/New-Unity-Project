using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : Environment
{
    //����ʱ��ʱ�������
    private const float timeLimit = 24 * 6;

    public int[] knockTime;
    private int index;
    private float beginTime;

    public CatManager catManager;
    public MouseManager mouseManager;
    public PeopleManager peopleManager;

    override
    protected void OnStart()
    {
        action = new UnityAction<int>(Call);
        unityEvent = new UnityEvent<int>();
        Init();
        beginTime = Time.time;
        index = 0;
    }

    //����ʱ������Ƿ�Invoke�¼�
    private void Update()
    {
        float time = Time.time - beginTime;
        if(index >= knockTime.Length)
        {
            if (time > timeLimit)
            {
                beginTime = Time.time;
                index = 0;
            }
        }
        else if(time > knockTime[index])
        {
            Clock.Instance.unityEvent.Invoke((int)myEntity);
            index++;
        }
    }

    override
    protected void InitAll()
    {
        Clock.Instance.unityEvent.RemoveAllListeners();
        //CatManager.Instance.Init();
        //MouseManager.Instance.Init();
        //PeopleManager.Instance.Init();
        catManager.Init();
        mouseManager.Init();
        peopleManager.Init();
        Clock.Instance.Init();
    }

    override
    public void Init()
    {
        Clock.Instance.unityEvent.AddListener(action);
    }

    //���²����õİ�ť
    override
    public void Knock()
    {
        beginTime = Time.time;
        index = 0;
        Clock.Instance.unityEvent.Invoke((int)myEntity);
    }
}
