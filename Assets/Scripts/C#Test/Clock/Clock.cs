public class Clock : Creature
{
    public Clock(int id) : base(id)
    {
        this.name = "Clock";
        this.action = "到时间了";
    }
}
