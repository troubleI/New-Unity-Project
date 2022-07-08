using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    //每行点的X值
    public int[] posX;
 
    //行最大量   显示数量   道具数量    每行高度
    public int lineLimit, showLimit, bagLimit, lineHeight;
    //PosY的初始值
    public int beginPosY;

    //展示行数   能显示的最上行   能显示第一个道具序号
    private int showLine, topLine, firstItem;

    private RectTransform rectTransform;
    //获得子物体列表
    private List<GameObject> gameObjs;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        //处理子物体x坐标数组
        int line = bagLimit / lineLimit;
        if(bagLimit % lineLimit != 0)
        {
            line++;
        }
        //设置content大小
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, line * lineHeight);
        //对变量初始化
        firstItem = 0;
        showLine = showLimit / lineLimit;
        topLine = 1 - showLine;
        //得到子物体
        gameObjs = Pool.Instance.InitObject(showLimit,this.transform);
    }

    void Update()
    {
        int nowTopLine = (int)rectTransform.anchoredPosition.y / lineHeight + 1;
        //若可显示的第一行发生改变则修改子物体位置
        if (nowTopLine != topLine)
            Move(nowTopLine);
    }

    private void Move(int nowTopLine)
    {
        //判断向上滑或向下滑
        bool isDown = topLine < nowTopLine;
        int changeLine = nowTopLine - topLine;
        //以行为单位处理
        for (int j = 0; j < Mathf.Abs(changeLine); j++)
        {
            //获取要修改的道具在pool中的序号
            int itemId = GetItemId(isDown);
            for (int i = 0; i < lineLimit; i++)
            {
                GameObject obj = gameObjs[itemId + i];
                Item item = obj.GetComponent<Item>();
                //得到目标道具应在行数
                int itemLine = GetItemLine(isDown);
                //配置子物体信息
                item.Init(itemLine * lineLimit + i + 1, bagLimit);
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX[i % lineLimit], beginPosY - (itemLine + 1) * lineHeight);
            }
            //修改子物体后，更改能显示的第一行信息
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
