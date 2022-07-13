using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseA : Mouse
{
    public MouseA(int id) : base(id)
    {
        this.name = "MouseA";
    }

    override
    public Entity Notice(int entity)
    {
        if (entity == (entity | (int)Entity.BlackCat))
        {
            gameObject.GetComponent<CreatureView>().Print(name + "ลÜมห");
            return Entity.MouseA;
        }
        else
            return Entity.none;
    }
}
