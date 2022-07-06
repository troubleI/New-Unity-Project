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
        Init();
    }

    public void Init()
    {
        Text text = this.GetComponentInChildren<Text>();
        text.text = name;
        this.gameObject.name = name;
    }
}
