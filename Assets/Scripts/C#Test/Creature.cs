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
    Entity Notice(int entity);
}
