/// <summary>
/// ��ʱ�����ݣ��Է�֮�������ĳ���������������
/// </summary>
public class MouseManager : Manager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new Mouse(id);
    }

    override
    protected void Init()
    {
        throw new System.NotImplementedException();
    }
}
