using System.Collections.Generic;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    private Dictionary<Entity, UnityEvent> dict;

    //private List<Entity> EventList;

    public EventManager()
    {
        dict = new Dictionary<Entity, UnityEvent>();
        foreach(Entity entity in Entity.GetValues(typeof(Entity)))
        {
            dict.Add(entity, new UnityEvent());
        }
        //EventList = new List<Entity>();
    }

    //判断Invoke事件
    public void Invoke(Entity entity)
    {
        dict[entity].Invoke();
        //EventList.Add(entity);
    }

    //判断监听对象
    public void AddListener(Entity entity,UnityAction action)
    {
        dict[entity].AddListener(action);
    }

    public void RemoveListener(Entity entity,UnityAction action)
    {
        dict[entity].RemoveListener(action);
    }
}
