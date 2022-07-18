public class ClockManager : Manager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new Clock(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.Clock;
        this.effectEntity = Entity.none;
        this.name = "Clock";
    }
}
