using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : People
{
    public Host(int id) : base(id)
    {
        this.name = "host";
    }

    override
    public Entity Notice(int entity)
    {
        return Entity.none;
    }
}
