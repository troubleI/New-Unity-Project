using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �б�Ҫ�Ļ�ʹ��״̬ģʽ�����������
/// </summary>
public enum Entity
{
    none = 0,
    Clock = 1,
    BlackCat = 2,
    MouseA = 4,
    Host = 8,
    Hostess = 16
}

public interface Creature
{
    //�ڱ��̳���дʱ��ÿһ�㶼���Ա��¼���Ӧ�������Ϳ���Ӱ��ĳ��Ⱥ������
    Entity Notice(int entity);
}
