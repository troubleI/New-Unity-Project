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

    //�ж�Invoke�¼�
    public void Invoke(Entity entity)
    {
        dict[entity].Invoke();
        //EventList.Add(entity);
    }

    //�жϼ�������
    public void AddListener(Entity entity,UnityAction action)
    {
        dict[entity].AddListener(action);
    }

    public void RemoveListener(Entity entity,UnityAction action)
    {
        dict[entity].RemoveListener(action);
    }
}
