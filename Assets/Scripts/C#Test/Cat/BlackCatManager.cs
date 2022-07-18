public class BlackCatManager : CatManager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new BlackCat(id);
    }
     
    override
    protected void Init()
    {
        this.myEntity = Entity.BlackCat;
        this.effectEntity = Entity.Clock;
        this.name = "BlackCat";
    }
}
