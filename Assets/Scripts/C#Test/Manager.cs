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

    //���ﴴ��GameObject������һЩ��ص�����
    protected void CreateCreature()
    {
        for (int i = 0; i < num; i++)
        {
            Creature creature = GetNewCreature(i);
            creatures.Add(creature);
            GameObject obj = Instantiate(prefab, this.transform);
            obj.name = name;
            //Ϊ�������������Invoke�¼�
            CreatureView creatureView = obj.GetComponent<CreatureView>();
            creatureView.creature = creature;
            creature.creature = creatureView;
            creature.manager = this;
        }
    }

    //�¼��ص�
    protected void Call()
    {
        foreach (Creature creature in creatures)
        {
            creature.Notice();
        }
        Knock();
    }

    //����Invoke�¼�
    public void Knock()
    {
        EventManager.Instance.Invoke(myEntity);
    }

    abstract
    protected void Init();

    //��ö�Ӧ��
    abstract
    protected Creature GetNewCreature(int id);
}
