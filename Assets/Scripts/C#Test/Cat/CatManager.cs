/// <summary>
/// ��ʱ�����ݣ��Է�֮�������ĳ���������������
/// </summary>
public class CatManager : Manager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new Cat(id);
    }

    override
    protected void Init()
    {
        throw new System.NotImplementedException();
    }
}
