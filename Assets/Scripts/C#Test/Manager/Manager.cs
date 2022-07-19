using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Manager : MonoBehaviour
{
    protected List<SpeciesModel> speciesModels;
    protected Dictionary<int, SpeciesView> speciesViews;

    public GameObject prefab;

    public int num;

    protected Entity myEntity;
    protected Entity effectEntity;
    protected string name;

    protected UnityAction action;

    void Start()
    {
        speciesModels = new List<SpeciesModel>();
        speciesViews = new Dictionary<int, SpeciesView>();
        Init();
        action = new UnityAction(Call);
        EventManager.Instance.AddListener(effectEntity,action);
        CreateCreature();
    }

    //这里创建GameObject，并做一些相关的配置
    protected void CreateCreature()
    {
        for (int i = 0; i < num; i++)
        {
            SpeciesModel creature = GetNewCreature(i);
            speciesModels.Add(creature);
            GameObject obj = Instantiate(prefab, this.transform);
            obj.name = name;
            speciesViews.Add(i, obj.GetComponent<SpeciesView>());
        }
    }

    //事件回调
    protected void Call()
    {
        foreach (SpeciesModel specie in speciesModels)
        {
            Notice(specie);
        }
        Knock();
    }

    //在被继承重写时，每一层都可以被事件响应，这样就可以影响某个群体整体
    virtual
    public void Notice(SpeciesModel specie)
    {
        speciesViews[specie.id].Print(specie.name + specie.action);
    }

    //主动Invoke事件
    public void Knock()
    {
        EventManager.Instance.Invoke(myEntity);
    }

    abstract
    protected void Init();

    //获得对应类
    abstract
    protected SpeciesModel GetNewCreature(int id);

    void OnDestroy()
    {
        EventManager.Instance.RemoveListener(effectEntity, action);
    }
}
