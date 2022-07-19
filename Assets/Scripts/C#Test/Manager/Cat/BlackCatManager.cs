public class BlackCatManager : CatManager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new BlackCatModel(id);
    }
     
    override
    protected void Init()
    {
        this.myEntity = Entity.BlackCat;
        this.effectEntity = Entity.Clock;
        this.name = "BlackCat";
    }
}
