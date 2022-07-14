using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 有必要的话使用状态模式，增加灵活性
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
    //在被继承重写时，每一层都可以被事件响应，这样就可以影响某个群体整体
    Entity Notice(int entity);
}
