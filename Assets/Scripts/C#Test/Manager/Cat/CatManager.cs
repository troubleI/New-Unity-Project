/// <summary>
/// ��ʱ�����ݣ��Է�֮�������ĳ���������������
/// </summary>
public class CatManager : Manager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new CatModel(id);
    }

    override
    protected void Init()
    {
        throw new System.NotImplementedException();
    }
}
