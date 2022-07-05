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

    //��ʼ���������ʱ��������ջ
    void Start()
    {
        texts.Push("");
        lastChangeTime = Time.time;
    }

    void Update()
    {
        Check(KeyCode.LeftAlt,ref isAlt);
        if(isAlt && Input.GetKeyDown(KeyCode.Z))
        {
            //��ջΪ�������ӿ��ַ������������ջ���ַ���
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

    //�жϰ���״̬
    private void Check(KeyCode key,ref bool checkKey)
    {
        if (Input.GetKeyDown(key))
        {
            checkKey = true;
        }
        if (Input.GetKeyUp(key))
        {
            checkKey = false;
        }
    }

    //��inputfield�����ı�
    public void Change()
    {
        //����򳷻ص���inputfield�����仯�����
        if (!changed && Time.time - lastChangeTime > timeLimit)
        {
            lastChangeTime = Time.time;
            texts.Push(text.text);
            Debug.Log(text.text);
        }
        changed = false;
    }
}