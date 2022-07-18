using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Manager : MonoBehaviour
{
    protected List<Creature> creatures;

    public GameObject prefab;

    public int num;

    protected Entity myEntity;
    protected Entity effectEntity;
    protected string name;

    void Start()
    {
        creatures = new List<Creature>();
        Init();
        EventManager.Instance.AddListener(effectEntity, new UnityAction(Call));
        CreateCreature();
    }

    //这里创建GameObject，并做一些相关的配置
    protected void CreateCreature()
    {
        for (int i = 0; i < num; i++)
        {
            Creature creature = GetNewCreature(i);
            creatures.Add(creature);
            GameObject obj = Instantiate(prefab, this.transform);
            obj.name = name;
            //为了物体可以主动Invoke事件
            CreatureView creatureView = obj.GetComponent<CreatureView>();
            creatureView.creature = creature;
            creature.creature = creatureView;
            creature.manager = this;
        }
    }

    //事件回调
    protected void Call()
    {
        foreach (Creature creature in creatures)
        {
            creature.Notice();
        }
        Knock();
    }

    //主动Invoke事件
    public void Knock()
    {
        EventManager.Instance.Invoke(myEntity);
    }

    abstract
    protected void Init();

    //获得对应类
    abstract
    protected Creature GetNewCreature(int id);
}
