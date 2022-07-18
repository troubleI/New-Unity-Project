public class HostessManager : PeopleManager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new Hostess(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.Hostess;
        this.effectEntity = Entity.MouseA;
        this.name = "Host";
    }
}
