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

    //���ﴴ��GameObject������һЩ��ص�����
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

    //�¼��ص�
    protected void Call()
    {
        foreach (SpeciesModel specie in speciesModels)
        {
            Notice(specie);
        }
        Knock();
    }

    //�ڱ��̳���дʱ��ÿһ�㶼���Ա��¼���Ӧ�������Ϳ���Ӱ��ĳ��Ⱥ������
    virtual
    public void Notice(SpeciesModel specie)
    {
        speciesViews[specie.id].Print(specie.name + specie.action);
    }

    //����Invoke�¼�
    public void Knock()
    {
        EventManager.Instance.Invoke(myEntity);
    }

    abstract
    protected void Init();

    //��ö�Ӧ��
    abstract
    protected SpeciesModel GetNewCreature(int id);

    void OnDestroy()
    {
        EventManager.Instance.RemoveListener(effectEntity, action);
    }
}
