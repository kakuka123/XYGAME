using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public GameObject flashGo;
    private float hideTimer;
    public float displayTime = 0.3f;
    public void DisplayFlash()
    {
        flashGo.SetActive(true);
        //隔段时间禁用物体
        hideTimer = Time.time + displayTime;
    }



    // Update is called once per frame
    void Update()
    {
        //如果火光启用,且到了隐藏时间
        if (flashGo.activeInHierarchy&&Time.time>=hideTimer)
        {
            flashGo.SetActive(false);
        }

        //测试

        if (Input.GetMouseButtonDown(0))
        {
            DisplayFlash();
        }
        
    }
}
