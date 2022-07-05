using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text hour,min,s;
    private bool run;
    private float beginTime;

    // 判断计时器是否在运行并更新
    void Update()
    {
        if (run)
        {
            float time = Time.time - beginTime;
            TimeSpan tS = new TimeSpan(0, 0, Convert.ToInt32(time));
            hour.text = tS.Hours.ToString("00");
            min.text = tS.Minutes.ToString("00");
            s.text = tS.Seconds.ToString("00");
        }
    }

    //计时器开始
    public void Begin()
    {
        run = true;
        beginTime = Time.time;
    }

    //计时器清零
    public void Stop()
    {
        run = false;
        hour.text = "00";
        min.text = "00";
        s.text = "00";
    }
}
