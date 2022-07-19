using UnityEngine;

public class ClockManager : Manager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new ClockModel(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.Clock;
        this.effectEntity = Entity.none;
        this.name = "Clock";
    }

    //根据时间决定是否Invoke事件
    void FixedUpdate()
    {
        foreach(ClockModel clock in speciesModels)
        {
            float time = Time.time - clock.beginTime;
            if (clock.index >= clock.knockTime.Length)
            {
                if (time > clock.timeLimit)
                    clock.Init();
            }
            else if (time > clock.knockTime[clock.index])
            {
                clock.index++;
                Knock();
            }
        }
    }
}
