using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int addNum;

    public void AddNum()
    {
        ExampleScript.callDelegate?.Invoke(addNum);
    }
}
