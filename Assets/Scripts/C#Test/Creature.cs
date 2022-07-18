public enum Entity
{
    none = 0,
    Clock = 1,
    BlackCat = 2,
    MouseA = 4,
    Host = 8,
    Hostess = 16
}

public abstract class Creature
{
    protected int id;
    protected string name;
    protected string action;

    //public GameObject gameObject;
    public CreatureView creature;
    public Manager manager;

    protected Creature(int id)
    {
        this.id = id;
    }

    //在被继承重写时，每一层都可以被事件响应，这样就可以影响某个群体整体
    virtual
    public void Notice()
    {
        creature.Print(name + action);
    }

    //主动Invoke事件
    public void Knock()
    {
        creature.Init();
        manager.Knock();
    }
}
