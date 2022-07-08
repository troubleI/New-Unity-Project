using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    //ÿ�е��Xֵ
    public int[] posX;
 
    //�������   ��ʾ����   ��������    ÿ�и߶�
    public int lineLimit, showLimit, bagLimit, lineHeight;
    //PosY�ĳ�ʼֵ
    public int beginPosY;

    //չʾ����   ����ʾ��������   ����ʾ��һ���������
    private int showLine, topLine, firstItem;

    private RectTransform rectTransform;
    //����������б�
    private List<GameObject> gameObjs;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        //����������x��������
        int line = bagLimit / lineLimit;
        if(bagLimit % lineLimit != 0)
        {
            line++;
        }
        //����content��С
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, line * lineHeight);
        //�Ա�����ʼ��
        firstItem = 0;
        showLine = showLimit / lineLimit;
        topLine = 1 - showLine;
        //�õ�������
        gameObjs = Pool.Instance.InitObject(showLimit,this.transform);
    }

    void Update()
    {
        int nowTopLine = (int)rectTransform.anchoredPosition.y / lineHeight + 1;
        //������ʾ�ĵ�һ�з����ı����޸�������λ��
        if (nowTopLine != topLine)
            Move(nowTopLine);
    }

    private void Move(int nowTopLine)
    {
        //�ж����ϻ������»�
        bool isDown = topLine < nowTopLine;
        int changeLine = nowTopLine - topLine;
        //����Ϊ��λ����
        for (int j = 0; j < Mathf.Abs(changeLine); j++)
        {
            //��ȡҪ�޸ĵĵ�����pool�е����
            int itemId = GetItemId(isDown);
            for (int i = 0; i < lineLimit; i++)
            {
                GameObject obj = gameObjs[itemId + i];
                Item item = obj.GetComponent<Item>();
                //�õ�Ŀ�����Ӧ������
                int itemLine = GetItemLine(isDown);
                //������������Ϣ
                item.Init(itemLine * lineLimit + i + 1, bagLimit);
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX[i % lineLimit], beginPosY - (itemLine + 1) * lineHeight);
            }
            //�޸�������󣬸�������ʾ�ĵ�һ����Ϣ
            firstItem = isDown ? itemId + lineLimit : itemId;
            topLine += changeLine > 0 ? 1 : -1;
        }
    }

    private int GetItemId(bool isDown)
    {
        if (isDown)
            return firstItem % showLimit;
        else
            return (firstItem + (lineLimit * (showLine - 1))) % showLimit;
    }

    private int GetItemLine(bool isDown)
    {
        if (isDown)
            return topLine + showLine - 1;
        else
            return topLine - 2;
    }
}
