using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUndo : MonoBehaviour
{
    public InputField text;
    public float timeLimit;
    private Stack<string> texts = new Stack<string>();
    private bool isAlt,changed;
    private float lastChangeTime;

    //初始化最后输入时间与输入栈
    void Start()
    {
        texts.Push("");
        lastChangeTime = Time.time;
    }

    void Update()
    {
        isAlt = IsKeyCode(KeyCode.LeftAlt,isAlt);
        if(isAlt && Input.GetKeyDown(KeyCode.Z))
        {
            //若栈为空则添加空字符串，否则输出栈内字符串
            if(texts.Count != 0)
            {
                if(text.text != "" && texts.Peek() == text.text)
                {
                    texts.Pop();
                }
                text.text = texts.Pop();
                changed = true;
            }
            else
            {
                texts.Push("");
            }
        }
    }

    //判断按键状态
    private bool IsKeyCode(KeyCode key,bool checkKey)
    {
        if (Input.GetKeyDown(key))
        {
            return true;
        }
        if (Input.GetKeyUp(key))
        {
            return false;
        }
        return checkKey;
    }

    //若inputfield发生改变
    public void Change()
    {
        //解决因撤回导致inputfield发生变化的情况
        if (!changed && Time.time - lastChangeTime > timeLimit)
        {
            lastChangeTime = Time.time;
            texts.Push(text.text);
            Debug.Log(text.text);
        }
        changed = false;
    }
}
