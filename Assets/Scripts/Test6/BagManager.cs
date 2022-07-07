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
    //PosY的初始值
    public int beginPosY;

    private int topLine;
    private RectTransform rectTransform;

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
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, line * lineHeight);
        topLine = 0;
        Pool.Instance.InitObject(showLimit,this.transform);
    }

    void Update()
    {
        //检测可显示的第一行改变
        int posY = (int)rectTransform.localPosition.y;
        int nowTopLine = posY / lineHeight + 1;
        if (nowTopLine != topLine)
        {
            topLine = nowTopLine;
            Move();
        }
    }

    /// <summary>
    /// 移动子物体
    /// </summary>
    private void Move()
    {
        //获得子物体列表
        List<GameObject> gameObjs = Pool.Instance.GetObject();
        int line = topLine;
        for(int i = 0;i < showLimit;i++)
        {
            GameObject obj = gameObjs[i];
            Item item = obj.GetComponent<Item>();
            //配置子物体信息
            item.Init((topLine - 1) * 3 + i + 1, bagLimit);
            //设置子物体位置
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX[i % 3], beginPosY - line * lineHeight);
            if(i % 3 == 2)
            {
                line ++;
            }
        }
    }
}
