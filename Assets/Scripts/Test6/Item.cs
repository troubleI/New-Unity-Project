using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        Init(true);
    }

    public void Init(bool real)
    {
        Text text = this.GetComponentInChildren<Text>();
        if (real)
        {
            text.text = name;
        }
        else
        {
            text.text = "";
        }
    }
}
