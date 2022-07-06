using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    //�»�����
    public float downLimit;
    //�ϻ�����
    public float upLimit;
    //�������
    public int lineLimit;
    //�����Ʒ��
    public int bagLimit;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnChange()
    {
        //���»�
        if(rectTransform.localPosition.y > downLimit)
        {
            Slip(true);
        }
        //���ϻ�
        else if(rectTransform.localPosition.y < upLimit)
        {
            Slip(false);
        }
    }

    private void Slip(bool isDown)
    {
        int num;
        //����Contentλ��
        if (isDown)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, upLimit, rectTransform.localPosition.z);
            //��ȡ���·��������
            num = int.Parse(this.transform.GetChild(bagLimit - 1).GetComponent<Item>().name);
        }
        else
        {
            transform.localPosition = new Vector3(rectTransform.localPosition.x, downLimit, rectTransform.localPosition.z);
            //��ȡ�׸��������
            num = int.Parse(this.transform.GetChild(0).GetComponent<Item>().name);
        }
        //�ƶ��������������
        for (int i = 0; i < lineLimit; i++)
        {
            int changeNum = 0,nowNum = num + i + 1;
            if (!isDown)
            {
                changeNum = bagLimit - 1;
                nowNum = num - i - 1;
            }
            //�������ƶ���������
            Transform item = this.transform.GetChild(changeNum);
            Item item_init = item.GetComponent<Item>();
            item_init.name = (nowNum).ToString();
            item_init.Init();
            if (isDown)
            {
                item.SetAsLastSibling();
            }
            else
            {
                item.SetAsFirstSibling();
            }
        }
    }
}
