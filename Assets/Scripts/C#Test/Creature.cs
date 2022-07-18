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

    //�ڱ��̳���дʱ��ÿһ�㶼���Ա��¼���Ӧ�������Ϳ���Ӱ��ĳ��Ⱥ������
    virtual
    public void Notice()
    {
        creature.Print(name + action);
    }

    //����Invoke�¼�
    public void Knock()
    {
        creature.Init();
        manager.Knock();
    }
}
