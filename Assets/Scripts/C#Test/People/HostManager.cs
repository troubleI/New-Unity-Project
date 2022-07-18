public class HostManager : PeopleManager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new Host(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.Host;
        this.effectEntity = Entity.Hostess;
        this.name = "Host";
    }
}
