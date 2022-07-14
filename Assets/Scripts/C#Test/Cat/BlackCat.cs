using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCat : Cat
{
    public BlackCat(int id) : base(id)
    {
        this.name = "blackCat";
        this.myEntity = Entity.BlackCat;
    }

    override
    public Entity Notice(int entity)
    {
        if (entity == (entity | (int)Entity.Clock))
        {
            gameObject.GetComponent<CreatureView>().Print(name + "╫пак");
            return myEntity;
        }
        else
            return Entity.none;
    }
}
