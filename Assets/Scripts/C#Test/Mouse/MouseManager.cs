using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : Manager
{
    public int mouseA_num;

    override
    protected void CreateCreature()
    {
        for (int i = 0; i < mouseA_num; i++)
        {
            CreateMouseA(i);
        }
    }

    private void CreateMouseA(int id)
    {
        Mouse mouse = new MouseA(id);
        creatures.Add(mouse);
        GameObject obj = Instantiate(prefab,this.transform);
        obj.name = "MouseA";
        mouse.gameObject = obj;
    }
}
