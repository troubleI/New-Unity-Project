/// <summary>
/// ��ʱ�����ݣ��Է�֮�������ĳ���������������
/// </summary>
public class PeopleManager : Manager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new People(id);
    }

    override
    protected void Init()
    {
        throw new System.NotImplementedException();
    }
}
