/// <summary>
/// ��ʱ�����ݣ��Է�֮�������ĳ���������������
/// </summary>
public class MouseManager : Manager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new MouseModel(id);
    }

    override
    protected void Init()
    {
        throw new System.NotImplementedException();
    }
}
