using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class ResourceTool
{
    public static GameObject LoadGameObject(string path)
    {
        return Resources.Load<GameObject>(path);
    }
}
