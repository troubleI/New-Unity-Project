using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Creature
{
    protected int id;
    protected string name;

    public GameObject gameObject;

    public Cat(int id)
    {
        this.id = id;
        this.name = "cat";
    }

    virtual
    public Entity Notice(int entity)
    {
        return Entity.none;
    }
}
