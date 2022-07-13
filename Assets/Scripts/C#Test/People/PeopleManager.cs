using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PeopleManager : MonoBehaviour
{
    //Dictionary<int, Creature> peoples = new Dictionary<int, Creature>();
    List<People> peoples;

    public int host_num,hostess_num;
    public GameObject prefab;

    public UnityAction<int> action;

    private void Start()
    {
        peoples = new List<People>();
        action = new UnityAction<int>(Call);
        Init();
        for (int i = 0; i < host_num; i++)
        {
            CreateHost(i);
        }
        for (int i = 0; i < hostess_num; i++)
        {
            CreateHostess(i + host_num);
        }
    }

    private void CreateHost(int id)
    {
        People people = new Host(id);
        peoples.Add(people);
        GameObject obj = Instantiate(prefab, this.transform);
        obj.name = "Host";
        people.gameObject = obj;
    }

    private void CreateHostess(int id)
    {
        People people = new Hostess(id);
        peoples.Add(people);
        GameObject obj = Instantiate(prefab, this.transform);
        obj.name = "Hostess";
        people.gameObject = obj;
    }

    private void Call(int entity)
    {
        if (peoples.Count == 0)
            return;
        int beforeEntity = entity;
        foreach (People people in peoples)
        {
            entity |= (int)people.Notice(entity);
        }
        if (beforeEntity != entity)
            Remove();
        Clock.instance.unityEvent.Invoke(entity);
    }

    public void Init()
    {
        Clock.instance.unityEvent.AddListener(action);
    }

    private void Remove()
    {
        Clock.instance.unityEvent.RemoveListener(action);
    }
}
