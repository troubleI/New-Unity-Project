using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaOOP : MonoBehaviour
{
    public TextAsset luaScript;

    // Start is called before the first frame update
    void Start()
    {
        LuaEnv luaenv = new LuaEnv();
        luaenv.DoString(luaScript.text);
        luaenv.Dispose();
    }
}
