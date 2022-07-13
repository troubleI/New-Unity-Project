using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Creature
{
    protected int id;
    protected string name;

    public GameObject gameObject;

    public Mouse(int id)
    {
        this.id = id;
        this.name = "mouse";
    }

    virtual
    public Entity Notice(int entity)
    {
        return Entity.none;
    }
}
