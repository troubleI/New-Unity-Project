using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCat : Cat
{
    public BlackCat(int id) : base(id)
    {
        this.name = "blackCat";
    }

    override
    public Entity Notice(int entity)
    {
        if (entity == (entity | (int)Entity.Clock))
        {
            gameObject.GetComponent<CreatureView>().Print(name + "����");
            return Entity.BlackCat;
        }
        else
            return Entity.none;
    }
}
