using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostess : People
{
    public Hostess(int id) : base(id)
    {
        this.name = "hostess";
        this.myEntity = Entity.Hostess;
    }

    override
    public Entity Notice(int entity)
    {
        if (entity == (entity | (int)Entity.MouseA))
        {
            gameObject.GetComponent<CreatureView>().Print(name + "ะัมห");
            return myEntity;
        }
        else
            return Entity.none;
    }
}

