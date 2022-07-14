using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PeopleManager : Manager
{
    public int host_num,hostess_num;

    override
    protected void CreateCreature()
    {
        for (int i = 0; i < host_num; i++)
        {
            CreateHost(i);
        }
        for (int i = 0; i < hostess_num; i++)
        {
            CreateHostess(i + host_num);
        }
    }

    private void CreateHost(int id)
    {
        People people = new Host(id);
        creatures.Add(people);
        GameObject obj = Instantiate(prefab, this.transform);
        obj.name = "Host";
        people.gameObject = obj;
    }

    private void CreateHostess(int id)
    {
        People people = new Hostess(id);
        creatures.Add(people);
        GameObject obj = Instantiate(prefab, this.transform);
        obj.name = "Hostess";
        people.gameObject = obj;
    }
}
