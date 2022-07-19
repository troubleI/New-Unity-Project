public class HostManager : PeopleManager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new HostModel(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.Host;
        this.effectEntity = Entity.Hostess;
        this.name = "Host";
    }
}
