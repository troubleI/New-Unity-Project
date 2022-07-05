using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private bool onDown;
    private Transform cubeTransform;

    // Update is called once per frame
    void Update()
    {
        //≈–∂œ Û±Í◊¥Ã¨
        if (Input.GetMouseButtonDown(0))
        {
            onDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            onDown = false;
            cubeTransform = null;
        }
        
        if (onDown)
        {
            if(cubeTransform == null)
            {
                CheckRayCast();
            }
            else
            {
                Move();
                Zoom();
            }
        }
    }

    //≈–∂œ…‰œﬂ «∑Ò…‰µΩcube
    private void CheckRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //ºÏ≤‚…‰œﬂ «∑Ò…‰µΩ
        if(Physics.Raycast(ray,out hit))
        {
            cubeTransform = hit.transform;
        }
    }

    //“∆∂Øcube
    private void Move()
    {
        Vector3 cubePos = Camera.main.WorldToScreenPoint(cubeTransform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubePos.z);
        cubeTransform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    //Àı∑≈cube
    private void Zoom()
    {
        float scaleNum = Input.GetAxis("Mouse ScrollWheel");
        if(scaleNum != 0)
        {
            scaleNum += 1;
            Vector3 cubeScale = new Vector3(cubeTransform.localScale.x, cubeTransform.localScale.y, cubeTransform.localScale.z) * scaleNum;
            cubeTransform.localScale = cubeScale;
        }
    }
}
