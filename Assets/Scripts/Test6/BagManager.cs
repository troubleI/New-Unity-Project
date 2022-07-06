using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    //每行点的X值
    public int[] posX;

    //行最大量
    public int lineLimit;
    //显示数量
    public int showLimit;
    //物品数量
    public int bagLimit;
    //每行高度
    public int lineHeight;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        //处理子物体x坐标数组
        int line = bagLimit / 3;
        if(bagLimit % 3 != 0)
        {
            line++;
        }
        //设置content大小
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, line * lineHeight - 10);
    }

    public void OnChange()
    {
        int topLine = int.Parse(this.transform.GetChild(0).GetComponent<Item>().name) / 3;
        //向下滑
        if ((topLine + 1) * lineHeight < rectTransform.anchoredPosition.y)
        {
            Down();
        }
        //向上滑
        else if (topLine * lineHeight > rectTransform.anchoredPosition.y && rectTransform.anchoredPosition.y > 0)
        {
            Up();
        }
    }

    private void Down()
    {
        //获取最下方子物体序号
        Transform lastItem = this.transform.GetChild(showLimit - 1);
        int num = int.Parse(lastItem.GetComponent<Item>().name);
        //处理遮罩外的子物体
        for (int i = 0;i < lineLimit; i++)
        {
            //获取对象子物体的现序号，与修改后序号
            int nowNum = 0, changeNum = num + i + 1;
            //获取并设置子物体
            Transform item = this.transform.GetChild(nowNum);
            Item item_init = item.GetComponent<Item>();
            item_init.name = changeNum.ToString();
            item_init.Init(num + i + 1 < bagLimit);
            //设置子物体位置
            (item as RectTransform).anchoredPosition = new Vector2(posX[changeNum % 3], (lastItem as RectTransform).anchoredPosition.y - lineHeight);
            item.SetAsLastSibling();
        }
    }

    private void Up()
    {
        //获取最上方子物体序号
        Transform firstItem = this.transform.GetChild(0);
        int num = int.Parse(firstItem.GetComponent<Item>().name);
        //处理遮罩外的子物体
        for (int i = 0; i < lineLimit; i++)
        {
            //获取对象子物体的现序号，与修改后序号
            int nowNum = showLimit - 1, changeNum = num - i - 1;
            //获取并设置子物体
            Transform item = this.transform.GetChild(nowNum);
            Item item_init = item.GetComponent<Item>();
            item_init.name = changeNum.ToString();
            item_init.Init(num - i - 1 > 0);
            //设置子物体位置
            (item as RectTransform).anchoredPosition = new Vector2(posX[changeNum % 3], (firstItem as RectTransform).anchoredPosition.y + lineHeight);
            item.SetAsFirstSibling();
        }
    }
}
