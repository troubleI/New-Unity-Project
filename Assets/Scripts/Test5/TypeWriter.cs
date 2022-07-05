using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public Text text;
    public float timeLimit;

    private string beginText; //你好，我是<color=#ff0000ff><i><b>打</b>字</i><b>机</b></color>。我是<b>粗体</b>。我是<i>斜体</i>。
    private string nowText;
    private Stack<string> labels;
    private int index;

    private bool state;
    private float beginTime;

    // Start is called before the first frame update
    void Start()
    {
        beginText = text.text;
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            //打字速度
            if(Time.time - beginTime > timeLimit)
            {
                beginTime = Time.time;
                //读下一个字符
                Next();
                //显示现在读过的字符
                text.text = nowText;
                //补充标签后缀
                if(labels.Count != 0)
                {
                    text.text += DisposeEnd();
                }
            }
        }
    }

    //初始化
    public void Begin()
    {
        state = true;
        index = 0;
        beginTime = Time.time;
        labels = new Stack<string>();
    }

    //处理下一个字符
    private void Next()
    {
        while (index < beginText.Length)
        {
            //若下标处于标签结束处,则补齐标签继续循环
            while (beginText[index] == '<' && beginText[index + 1] == '/')
            {
                while(beginText[index] != '>')
                {
                    nowText += beginText[index];
                    index++;
                }
                nowText += beginText[index];
                index++;
                labels.Pop();
            }
            //判断是否为标签，否则直接输出
            if (beginText[index] != '<')
            {
                nowText += beginText[index];
                index++;
                return;
            }
            //确定为标签，将标签入栈.
            string label = "";
            bool isLabel = true;
            while(beginText[index] != '>')
            {
                //遇到标签赋值的情况
                if(beginText[index] == '=')
                {
                    isLabel = false;
                    nowText += label;
                    labels.Push(label + ">");
                }
                if (isLabel)
                {
                    label += beginText[index];
                }
                else
                {
                    nowText += beginText[index];
                }
                index++;
            }
            //若标签未赋值则要入栈
            if (isLabel)
            {
                nowText += label;
                labels.Push(label + ">");
            }
            nowText += ">";
            index++;
        }
    }

    //处理标签后缀
    private string DisposeEnd()
    {
        string text_end = "";
        string[] label_end = labels.ToArray();
        for(int i =  0;i < label_end.Length; i++)
        {
            text_end += label_end[i].Insert(1, "/");
        }
        return text_end;
    }
}