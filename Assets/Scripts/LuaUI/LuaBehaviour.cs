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
        // Ϊÿ���ű�����һ�������Ļ�������һ���̶��Ϸ�ֹ�ű���ȫ�ֱ�����������ͻ
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
        //����lua·��
        string luaPath = Application.dataPath + "/Scripts/LuaUI/" + fileName + ".lua";
        //��ȡlua·����ָ��lua�ļ�����
        string strLuaContent = File.ReadAllText(luaPath);
        //��������ת��
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
