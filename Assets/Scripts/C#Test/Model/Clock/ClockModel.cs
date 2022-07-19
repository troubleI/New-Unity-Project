using UnityEngine;

public class ClockModel : SpeciesModel
{
    //����ʱ��ʱ�������
    public float timeLimit = 24 * 6;

    public int[] knockTime;
    public int index;
    public float beginTime;

    public ClockModel(int id) : base(id)
    {
        this.name = "Clock";
        this.action = "��ʱ����";
        knockTime = new int[] { 6,18,30};
        Init();
    }

    public void Init()
    {
        beginTime = Time.time;
        index = 0;
    }
}
