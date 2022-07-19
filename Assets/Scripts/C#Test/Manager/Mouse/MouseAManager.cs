using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAManager : MouseManager
{
    override
    protected SpeciesModel GetNewCreature(int id)
    {
        return new MouseAModel(id);
    }

    override
    protected void Init()
    {
        this.myEntity = Entity.MouseA;
        this.effectEntity = Entity.BlackCat;
        this.name = "MouseA";
    }
}
