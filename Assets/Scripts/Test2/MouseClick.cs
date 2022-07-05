using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private bool onClick;
    private Transform cubeTransform;

    // Update is called once per frame
    void Update()
    {
        //�ж����״̬
        if (Input.GetMouseButtonDown(0))
        {
            onClick = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            onClick = false;
            cubeTransform = null;
        }
        
        if (onClick)
        {
            if(cubeTransform == null)
            {
                IsRayCast();
            }
            else
            {
                Move();
                Zoom();
            }
        }
    }

    //�ж������Ƿ��䵽cube
    private void IsRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //��������Ƿ��䵽
        if(Physics.Raycast(ray,out hit))
        {
            cubeTransform = hit.transform;
        }
    }

    //�ƶ�cube
    private void Move()
    {
        Vector3 cubePos = Camera.main.WorldToScreenPoint(cubeTransform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubePos.z);
        cubeTransform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    //����cube
    private void Zoom()
    {
        float scaleNum = Input.GetAxis("Mouse ScrollWheel");
        if(scaleNum != 0)
        {
            scaleNum += 1;
            Vector3 cubeScale = new Vector3(cubeTransform.localScale.x * scaleNum, cubeTransform.localScale.y * scaleNum, cubeTransform.localScale.z * scaleNum);
            cubeTransform.localScale = cubeScale;
        }
    }
}
