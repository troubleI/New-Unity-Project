using UnityEngine;

public class ClockView : CreatureView
{
    //关于时钟时间的设置
    private const float timeLimit = 24 * 6;

    public int[] knockTime;
    private int index;
    private float beginTime;

    public Entity myEntity;

    override
    public void Init()
    {
        beginTime = Time.time;
        index = 0;
    }

    //根据时间决定是否Invoke事件
    void Update()
    {
        float time = Time.time - beginTime;
        if (index >= knockTime.Length)
        {
            if (time > timeLimit)
            {
                beginTime = Time.time;
                index = 0;
            }
        }
        else if (time > knockTime[index])
        {
            creature.Knock();
            index++;
        }
    }
}
