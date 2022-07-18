using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    private UnityEvent ClockEvent;
    private UnityEvent BlackCatEvent;
    private UnityEvent MouseAEvent;
    private UnityEvent HostessEvent;
    private UnityEvent HostEvent;

    //private List<Entity> EventList;

    public EventManager()
    {
        ClockEvent = new UnityEvent();
        BlackCatEvent = new UnityEvent();
        MouseAEvent = new UnityEvent();
        HostessEvent = new UnityEvent();
        HostEvent = new UnityEvent();
        //EventList = new UnityEvent();
    }

    //判断Invoke事件
    public void Invoke(Entity entity)
    {
        switch(entity)
        {
            case Entity.Clock:
                ClockEvent.Invoke();
                break;
            case Entity.BlackCat:
                BlackCatEvent.Invoke();
                break;
            case Entity.MouseA:
                MouseAEvent.Invoke();
                break;
            case Entity.Hostess:
                HostessEvent.Invoke();
                break;
            case Entity.Host:
                HostEvent.Invoke();
                break;
        }
        //EventList.Add(entity);
    }

    //判断监听对象
    public void AddListener(Entity entity,UnityAction action)
    {
        switch (entity)
        {
            case Entity.Clock:
                ClockEvent.AddListener(action);
                break;
            case Entity.BlackCat:
                BlackCatEvent.AddListener(action);
                break;
            case Entity.MouseA:
                MouseAEvent.AddListener(action);
                break;
            case Entity.Hostess:
                HostessEvent.AddListener(action);
                break;
            case Entity.Host:
                HostEvent.AddListener(action);
                break;
        }
    }
}
