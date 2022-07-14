using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Creature
{
    protected int id;
    protected string name;
    protected Entity myEntity;

    public GameObject gameObject;

    public People(int id)
    {
        this.id = id;
        this.name = "people";
        this.myEntity = Entity.none;
    }

    virtual
    public Entity Notice(int entity)
    {
        return Entity.none;
    }
}
