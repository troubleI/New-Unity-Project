using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public Text text;
    public float timeLimit;

    private string beginText; //��ã�����<color=#ff0000ff><i><b>��</b>��</i><b>��</b></color>������<b>����</b>������<i>б��</i>��
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
            //�����ٶ�
            if(Time.time - beginTime > timeLimit)
            {
                beginTime = Time.time;
                //����һ���ַ�
                Next();
                //��ʾ���ڶ������ַ�
                text.text = nowText;
                //�����ǩ��׺
                if(labels.Count != 0)
                {
                    text.text += DisposeEnd();
                }
            }
        }
    }

    //��ʼ��
    public void Begin()
    {
        state = true;
        index = 0;
        beginTime = Time.time;
        labels = new Stack<string>();
    }

    //������һ���ַ�
    private void Next()
    {
        while (index < beginText.Length)
        {
            //���±괦�ڱ�ǩ������,�����ǩ����ѭ��
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
            //�ж��Ƿ�Ϊ��ǩ������ֱ�����
            if (beginText[index] != '<')
            {
                nowText += beginText[index];
                index++;
                return;
            }
            //ȷ��Ϊ��ǩ������ǩ��ջ.
            string label = "";
            bool isLabel = true;
            while(beginText[index] != '>')
            {
                //������ǩ��ֵ�����
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
            //����ǩδ��ֵ��Ҫ��ջ
            if (isLabel)
            {
                nowText += label;
                labels.Push(label + ">");
            }
            nowText += ">";
            index++;
        }
    }

    //�����ǩ��׺
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