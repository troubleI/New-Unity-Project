using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItemManager : MonoBehaviour
{
    public GameObject prefab;

    //记录当前是否有提示框
    private GameObject nowObj;

    void Start()
    {
        nowObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //若有提示框存在则关闭，无则打开
            if (nowObj != null)
            {
                Destroy(nowObj);
                nowObj = null;
            }
            else
            {
                Vector2 mousePos = Input.mousePosition;
                GameObject obj = Instantiate<GameObject>(prefab, this.transform);
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                //设置位置
                rectTransform.position = mousePos;
                //设置中心点
                rectTransform.pivot = GetPivot(rectTransform);
                nowObj = obj;
            }
        }
    }

    /// <summary>
    /// 设置提示框中心点
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <returns></returns>
    private Vector2 GetPivot(RectTransform rectTransform)
    {
        int pivotX = 0, pivotY = 0;
        if(IsLeft(rectTransform))
        {
            pivotX = 1;
        }
        if (IsDown(rectTransform))
        {
            pivotY = 1;
        }
        return new Vector2(pivotX, pivotY);
    }

    //判断提示框能否出现在左边
    private bool IsLeft(RectTransform rectTransform)
    {
        return rectTransform.anchoredPosition.x - rectTransform.sizeDelta.x > 0;
    }

    //判断提示框能否出现在下边
    private bool IsDown(RectTransform rectTransform)
    {
        return rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y > 0;
    }
}
