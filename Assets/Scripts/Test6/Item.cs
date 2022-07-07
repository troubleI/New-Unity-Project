using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init(0,0);
    }

    public void Init(int id,int limit)
    {
        Text text = this.GetComponentInChildren<Text>();
        if (id <= limit)
        {
            text.text = id.ToString();
        }
        else
        {
            text.text = "";
        }
    }
}
