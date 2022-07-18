using UnityEngine;

public class ClockView : CreatureView
{
    //����ʱ��ʱ�������
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

    //����ʱ������Ƿ�Invoke�¼�
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
