using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    //ÿ�е��Xֵ
    public int[] posX;
 
    //�������
    public int lineLimit;
    //��ʾ����
    public int showLimit;
    //��Ʒ����
    public int bagLimit;
    //ÿ�и߶�
    public int lineHeight;
    //PosY�ĳ�ʼֵ
    public int beginPosY;

    private int topLine;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        //����������x��������
        int line = bagLimit / 3;
        if(bagLimit % 3 != 0)
        {
            line++;
        }
        //����content��С
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, line * lineHeight);
        topLine = 0;
        Pool.Instance.InitObject(showLimit,this.transform);
    }

    void Update()
    {
        //������ʾ�ĵ�һ�иı�
        int posY = (int)rectTransform.localPosition.y;
        int nowTopLine = posY / lineHeight + 1;
        if (nowTopLine != topLine)
        {
            topLine = nowTopLine;
            Move();
        }
    }

    /// <summary>
    /// �ƶ�������
    /// </summary>
    private void Move()
    {
        //����������б�
        List<GameObject> gameObjs = Pool.Instance.GetObject();
        int line = topLine;
        for(int i = 0;i < showLimit;i++)
        {
            GameObject obj = gameObjs[i];
            Item item = obj.GetComponent<Item>();
            //������������Ϣ
            item.Init((topLine - 1) * 3 + i + 1, bagLimit);
            //����������λ��
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX[i % 3], beginPosY - line * lineHeight);
            if(i % 3 == 2)
            {
                line ++;
            }
        }
    }
}
