/// <summary>
/// ��ʱ�����ݣ��Է�֮�������ĳ���������������
/// </summary>
public class PeopleManager : Manager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new PeopleModel(id);
    }

    override
    protected void Init()
    {
        throw new System.NotImplementedException();
    }
}
