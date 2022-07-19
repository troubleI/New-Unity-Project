using UnityEngine;

public class ClockModel : SpeciesModel
{
    //关于时钟时间的设置
    public float timeLimit = 24 * 6;

    public int[] knockTime;
    public int index;
    public float beginTime;

    public ClockModel(int id) : base(id)
    {
        this.name = "Clock";
        this.action = "到时间了";
        knockTime = new int[] { 6,18,30};
        Init();
    }

    public void Init()
    {
        beginTime = Time.time;
        index = 0;
    }
}
