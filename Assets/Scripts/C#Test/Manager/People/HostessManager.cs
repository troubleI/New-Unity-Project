public class HostessManager : PeopleManager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new HostessModel(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.Hostess;
        this.effectEntity = Entity.MouseA;
        this.name = "Host";
    }
}
