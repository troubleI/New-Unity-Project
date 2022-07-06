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

    private RectTransform rectTransform;

    // Start is called before the first frame update
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
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, line * lineHeight - 10);
    }

    public void OnChange()
    {
        int topLine = int.Parse(this.transform.GetChild(0).GetComponent<Item>().name) / 3;
        //���»�
        if ((topLine + 1) * lineHeight < rectTransform.anchoredPosition.y)
        {
            Down();
        }
        //���ϻ�
        else if (topLine * lineHeight > rectTransform.anchoredPosition.y && rectTransform.anchoredPosition.y > 0)
        {
            Up();
        }
    }

    private void Down()
    {
        //��ȡ���·����������
        Transform lastItem = this.transform.GetChild(showLimit - 1);
        int num = int.Parse(lastItem.GetComponent<Item>().name);
        //�����������������
        for (int i = 0;i < lineLimit; i++)
        {
            //��ȡ���������������ţ����޸ĺ����
            int nowNum = 0, changeNum = num + i + 1;
            //��ȡ������������
            Transform item = this.transform.GetChild(nowNum);
            Item item_init = item.GetComponent<Item>();
            item_init.name = changeNum.ToString();
            item_init.Init(num + i + 1 < bagLimit);
            //����������λ��
            (item as RectTransform).anchoredPosition = new Vector2(posX[changeNum % 3], (lastItem as RectTransform).anchoredPosition.y - lineHeight);
            item.SetAsLastSibling();
        }
    }

    private void Up()
    {
        //��ȡ���Ϸ����������
        Transform firstItem = this.transform.GetChild(0);
        int num = int.Parse(firstItem.GetComponent<Item>().name);
        //�����������������
        for (int i = 0; i < lineLimit; i++)
        {
            //��ȡ���������������ţ����޸ĺ����
            int nowNum = showLimit - 1, changeNum = num - i - 1;
            //��ȡ������������
            Transform item = this.transform.GetChild(nowNum);
            Item item_init = item.GetComponent<Item>();
            item_init.name = changeNum.ToString();
            item_init.Init(num - i - 1 > 0);
            //����������λ��
            (item as RectTransform).anchoredPosition = new Vector2(posX[changeNum % 3], (firstItem as RectTransform).anchoredPosition.y + lineHeight);
            item.SetAsFirstSibling();
        }
    }
}
