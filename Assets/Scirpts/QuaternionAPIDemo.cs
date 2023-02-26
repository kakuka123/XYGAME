using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionAPIDemo : MonoBehaviour
{


    public Transform tf;
    private void OnGUI()
    {
        if (GUILayout.Button(""))
        {
            //1欧拉角-->四元数
            //Quaternion.Euler(欧拉角)//可以添向量和xyz

            //2四元数-->欧拉角
            Quaternion qt = this.transform.rotation;
            Vector3 euler = qt.eulerAngles;

            //3.轴/角  参数:角度,旋转轴
            //Quaternion.Euler(0, 50, 0); //等同于下面这句,但是轴还要单独写
            Quaternion.AngleAxis(50,Vector3.up);//任意轴向均可
        }


        if (GUILayout.Button("LookRotation"))
        {

            //z轴指向一个方向
            //当前物体注视tf旋转
            Vector3 dir = tf.position - this.transform.position;
            //当前物体 注视旋转
            this.transform.rotation=Quaternion.LookRotation(dir);
        }

        if (GUILayout.RepeatButton("RotateTowards"))
        {
            Quaternion dir = Quaternion.LookRotation(tf.position - this.transform.position);
            //差值旋转
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);
            //匀速旋转
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, dir, 0.1f);
        }

        if (GUILayout.RepeatButton("Angle"))
        {
            Quaternion dir = Quaternion.Euler(0, 90, 0);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);//从当前旋转角度转向目标角度,比例0.1f
            //如果当前旋转角度 接近目标旋转角度
            if (Quaternion.Angle(this.transform.rotation, dir) < 1)
            {
                this.transform.rotation = dir;
            }

            //不旋转 和世界同一
            //transform.rotation = Quaternion.identity;

        }
        if (GUILayout.RepeatButton("Angle2"))
        {
            //8.x轴注视旋转
            //this.transform.right = tf.position - this.transform.position;
            //x轴正方向-->注视目标位置的方向
            Quaternion.FromToRotation(Vector3.right, tf.position - this.transform.position);
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (GUILayout.RepeatButton("FromToRotation"))
        {
            //x轴注视旋转 t1
            //this.transform.right = tf.position - this.transform.position;
            //x轴正方向-->注视目标位置的方向
            Quaternion dir = Quaternion.FromToRotation(Vector3.right, this.transform.position);
            this.transform.rotation = dir;

        }

   



    }
}
