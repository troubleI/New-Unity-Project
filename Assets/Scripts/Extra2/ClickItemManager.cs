using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItemManager : MonoBehaviour
{
    public GameObject prefab;

    //��¼��ǰ�Ƿ�����ʾ��
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
            //������ʾ�������رգ������
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
                //����λ��
                rectTransform.position = mousePos;
                //�������ĵ�
                rectTransform.pivot = GetPivot(rectTransform);
                nowObj = obj;
            }
        }
    }

    /// <summary>
    /// ������ʾ�����ĵ�
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

    //�ж���ʾ���ܷ���������
    private bool IsLeft(RectTransform rectTransform)
    {
        return rectTransform.anchoredPosition.x - rectTransform.sizeDelta.x > 0;
    }

    //�ж���ʾ���ܷ�������±�
    private bool IsDown(RectTransform rectTransform)
    {
        return rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y > 0;
    }
}
