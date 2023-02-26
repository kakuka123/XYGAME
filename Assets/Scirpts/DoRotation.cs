using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRotation : MonoBehaviour
{

    public float hor=0;

    public float rotateSpeed = 1;
    // Update is called once per frame
    private void FixUpdate()
    {
        //玩家希望可以自定义按键
        //控制摄相机移动旋转
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if(x!=0||x!=0)
        RotateView( x, y);

    }

    private void RotateView( float x,  float y)
    {
        x *= rotateSpeed;
        y *= rotateSpeed;

        //沿Y轴旋转
        this.transform.Rotate(-y, 0, 0);
        //左右旋转,需要沿世界坐标系Y轴
        this.transform.Rotate(0, x, 0, Space.World);
    }
}
