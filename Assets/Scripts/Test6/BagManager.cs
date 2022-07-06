using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    //下滑限制
    public float downLimit;
    //上滑限制
    public float upLimit;
    //行最大量
    public int lineLimit;
    //最大物品量
    public int bagLimit;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnChange()
    {
        //向下滑
        if(rectTransform.localPosition.y > downLimit)
        {
            Slip(true);
        }
        //向上滑
        else if(rectTransform.localPosition.y < upLimit)
        {
            Slip(false);
        }
    }

    private void Slip(bool isDown)
    {
        int num;
        //设置Content位置
        if (isDown)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, upLimit, rectTransform.localPosition.z);
            //获取最下方物体序号
            num = int.Parse(this.transform.GetChild(bagLimit - 1).GetComponent<Item>().name);
        }
        else
        {
            transform.localPosition = new Vector3(rectTransform.localPosition.x, downLimit, rectTransform.localPosition.z);
            //获取首个物体序号
            num = int.Parse(this.transform.GetChild(0).GetComponent<Item>().name);
        }
        //移动遮罩外的子物体
        for (int i = 0; i < lineLimit; i++)
        {
            int changeNum = 0,nowNum = num + i + 1;
            if (!isDown)
            {
                changeNum = bagLimit - 1;
                nowNum = num - i - 1;
            }
            //设置需移动的子物体
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
