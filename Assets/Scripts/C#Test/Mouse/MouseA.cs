using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseA : Mouse
{
    public MouseA(int id) : base(id)
    {
        this.name = "MouseA";
        this.myEntity = Entity.MouseA;
    }

    override
    public Entity Notice(int entity)
    {
        if (entity == (entity | (int)Entity.BlackCat))
        {
            gameObject.GetComponent<CreatureView>().Print(name + "ลÜมห");
            return myEntity;
        }
        else
            return Entity.none;
    }
}
