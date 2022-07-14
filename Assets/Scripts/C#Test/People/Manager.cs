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

    //���ﴴ��GameObject����Ϊû�о���ҵ��������ʱ�Ƚϼ�ª
    abstract
    protected void CreateCreature();

    //�¼��ص�����ƥ���Ƿ������ػ�Ӱ�쵽�Լ���Ӱ��Ļ�ִ�ж���
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
        //������Ӱ���ȡ�����ģ�����ᱻ�ظ�Ӱ��
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
