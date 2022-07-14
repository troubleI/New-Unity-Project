using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatManager : Manager
{
    public int blackCat_num;

    override
    protected void CreateCreature()
    {
        for (int i = 0; i < blackCat_num; i++)
        {
            CreateBlackCat(i);
        }
    }

    private void CreateBlackCat(int id)
    {
        Cat cat = new BlackCat(id);
        creatures.Add(cat);
        GameObject obj = Instantiate(prefab, this.transform);
        obj.name = "BlackCat";
        cat.gameObject = obj;
    }
}
