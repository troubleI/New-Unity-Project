/// <summary>
/// 暂时无内容，以防之后有面对某个物种整体的需求
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
