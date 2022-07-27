using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

[Serializable]
public class Injection
{
    public string name;
    public GameObject value;
}

public class LuaBehaviour : MonoBehaviour
{
    public string luaScript;

    static LuaEnv luaEnv = new LuaEnv();

    private Action luaStart;
    private Action luaUpdate;
    private Action luaFixedUpdate;
    private Action luaOnDestroy;

    private LuaTable scriptEnv;

    void Awake()
    {
        luaEnv.AddLoader(CustomMyLoader);

        scriptEnv = luaEnv.NewTable();
        // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);

        luaEnv.DoString("require '" + luaScript + "'",luaScript,scriptEnv);

        Action luaAwake = scriptEnv.Get<Action>("Awake");
        scriptEnv.Get("Start", out luaStart);
        scriptEnv.Get("Update", out luaUpdate);
        scriptEnv.Get("FixedUpdate", out luaFixedUpdate);
        scriptEnv.Get("OnDestroy", out luaOnDestroy);

        if (luaAwake != null)
            luaAwake();
        
        //Instantiate(Resources.Load<GameObject>("UI/Panel1"));
    }

    // Start is called before the first frame update
    void Start()
    {
        if (luaStart != null)
            luaStart();
    }

    byte[] CustomMyLoader(ref string fileName)
    {
        byte[] byArrayReturn = null;
        //定义lua路径
        string luaPath = Application.dataPath + "/Scripts/LuaUI/" + fileName + ".lua";
        //读取lua路径中指定lua文件内容
        string strLuaContent = File.ReadAllText(luaPath);
        //数据类型转换
        byArrayReturn = System.Text.Encoding.UTF8.GetBytes(strLuaContent);
        return byArrayReturn;
    }

    void Update()
    {
        if (luaUpdate != null)
            luaUpdate();
    }

    void FixedUpdate()
    {
        if (luaFixedUpdate != null)
            luaFixedUpdate();
    }

    private void OnDestroy()
    {
        if (luaOnDestroy != null)
            luaOnDestroy();
        //scriptEnv.Dispose();
    }
}
