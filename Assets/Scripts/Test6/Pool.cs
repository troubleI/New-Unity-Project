using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;

    public GameObject prefab;

    private List<GameObject> gameObjs;

    private void Awake()
    {
        Instance = this;
        gameObjs = new List<GameObject>();
    }

    public List<GameObject> GetObject()
    {
        return gameObjs;
    }

    public void InitObject(int num,Transform parent)
    {
        for(int i = 0;i < num; i++)
        {
            gameObjs.Add(Instantiate(prefab, parent));
        }
    }
}
