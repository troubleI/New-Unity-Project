using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 可以合并类似Manager
/// </summary>


public class CatManager : MonoBehaviour
{
    //Dictionary<int, Creature> cats = new Dictionary<int, Creature>();
    List<Cat> cats;

    public int blackCat_num;
    public GameObject prefab;

    public UnityAction<int> action;

    private void Start()
    {
        cats = new List<Cat>();
        action = new UnityAction<int>(Call);
        Init();
        for (int i = 0; i < blackCat_num; i++)
        {
            CreateBlackCat(i);
        }
    }

    private void CreateBlackCat(int id)
    {
        Cat cat = new BlackCat(id);
        cats.Add(cat);
        GameObject obj = Instantiate(prefab, this.transform);
        obj.name = "BlackCat";
        cat.gameObject = obj;
    }

    public void Call(int entity)
    {
        if (cats.Count == 0)
            return;
        int beforeEntity = entity;
        foreach (Cat cat in cats)
        {
            entity |= (int)cat.Notice(entity);
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
