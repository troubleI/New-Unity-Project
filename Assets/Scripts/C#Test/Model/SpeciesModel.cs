public enum Entity
{
    none = 0,
    Clock = 1,
    BlackCat = 2,
    MouseA = 4,
    Host = 8,
    Hostess = 16
}

public abstract class SpeciesModel
{
    public int id;
    public string name;
    public string action;

    protected SpeciesModel(int id)
    {
        this.id = id;
    }
}
