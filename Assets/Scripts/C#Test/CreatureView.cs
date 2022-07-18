using UnityEngine;

public class CreatureView : MonoBehaviour
{
    public Creature creature;

    void Start()
    {
        Init();
    }

    virtual
    public void Init()
    {

    }

    virtual
    public void Print(string text)
    {
        Debug.Log(text);
    }
}
