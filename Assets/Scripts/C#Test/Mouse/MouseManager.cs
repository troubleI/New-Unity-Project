using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    //Dictionary<int, Creature> mouses = new Dictionary<int, Creature>();
    List<Mouse> mouses;

    public int mouseA_num;
    public GameObject prefab;

    public UnityAction<int> action;

    private void Start()
    {
        mouses = new List<Mouse>();
        action = new UnityAction<int>(Call);
        Init();
        for (int i = 0;i < mouseA_num; i++)
        {
            CreateMouseA(i);
        }
    }

    private void CreateMouseA(int id)
    {
        Mouse mouse = new MouseA(id);
        mouses.Add(mouse);
        GameObject obj = Instantiate(prefab,this.transform);
        obj.name = "MouseA";
        mouse.gameObject = obj;
    }

    private void Call(int entity)
    {
        if (mouses.Count == 0)
            return;
        int beforeEntity = entity;
        foreach (Mouse mouse in mouses)
        {
            entity |= (int)mouse.Notice(entity);
        }
        if(beforeEntity != entity)
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
