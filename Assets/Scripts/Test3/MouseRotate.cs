using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public GameObject[] cubes;
    private bool rotate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            rotate = false;
        }
        if (rotate)
        {
            foreach(GameObject gameObject in cubes)
            {
                gameObject.transform.Rotate(new Vector3(90, 90, 90) * Time.deltaTime);
            }
        }
    }
}
