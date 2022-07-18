using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAManager : MouseManager
{
    override
    protected Creature GetNewCreature(int id)
    {
        return new MouseA(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.MouseA;
        this.effectEntity = Entity.BlackCat;
        this.name = "MouseA";
    }
}
