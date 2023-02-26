using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionDemo : MonoBehaviour
{
    private Vector3 vect;



    private void OnGUI()
    {
        if (GUILayout.Button("设置物体旋转角度"))
        {
            Quaternion qt = new Quaternion();
            //旋转轴
            Vector3 axis = Vector3.up;
            //旋转弧度
            float rad = 50 * Mathf.Deg2Rad;

            //qt.x = Mathf.Sin(rad/ 2) * axis.x;
            //qt.y = Mathf.Sin(rad/ 2) * axis.y;
            //qt.z = Mathf.Sin(rad/ 2) * axis.z;
            //qt.w = Mathf.Cos(rad / 2);
            //this.transform.rotation = qt;

            //欧拉角-->四元数
            this.transform.rotation = Quaternion.Euler(0, 50, 0);
         


        }

        if (GUILayout.RepeatButton("沿X轴旋转"))
        {
            //如果20度 要变为50度   需要四元数用乘法(20*30)得到
            this.transform.rotation *= Quaternion.Euler(1, 0, 0);
            //Rotate也是四元数
            //this.transform.Rotate(1,0,0);
        }


        if (GUILayout.RepeatButton("沿y轴旋转"))
        {
            //this.transform.eulerAngles += new Vector3(0, 1, 0);
            this.transform.rotation *= Quaternion.Euler(0, 1, 0);
        }
        if (GUILayout.RepeatButton("沿z轴旋转"))
        {
            //this.transform.eulerAngles += new Vector3(0, 0, 1);
            this.transform.rotation *= Quaternion.Euler(0, 0, 1);
        }

  



    }


    private void Update()
    {
        Debug.DrawLine(this.transform.position, vect);

        if (Input.GetMouseButtonDown(0))
        {
            //vect向量 根据当前物体的旋转而旋转
            vect = this.transform.rotation * new Vector3(0, 0, 10);
            //vect向量 沿y轴旋转30度
            vect = Quaternion.Euler(0, 30, 0) * vect;
            //vect向量 移动到当前物体位置
            vect = this.transform.position + vect;                  
            //总结为下面的语句
            //vect = this.transform.position + Quaternion.Euler(0,30,0)* this.transform.rotation*new Vector3(0, 0, 10);

        }
    }





}

