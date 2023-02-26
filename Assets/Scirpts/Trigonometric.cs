using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometric : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Demo03();
    }


    private void Demo01()
    {
        //角度->弧度:弧度=角度*PI/180
        //float d1 = 30;
        //float r1 = d1 * Mathf.PI / 180;
        //float r2 = d1 * Mathf.Deg2Rad;
        //print(r1 + "--" + r2);
        //弧度->角度:角度=弧度*180/PI
        //float r1 = 1;
        //float d1 = r1 * 180 / Mathf.PI;
        //float d2 = r1 * Mathf.Rad2Deg;
        //print(d1 + "--" + d2);
    }
    private void Demo02()
    {
        //已知角度x 边长b
        //求:边长a
        //公式:a=tan x * b
        float x = 50, b = 20;
        float a = Mathf.Tan(x * Mathf.Deg2Rad) * b;


        //已知边长a 边长b
        //求角度x
        //公式: x=arctan a/b
        float angle = Mathf.Atan(a / b)*Mathf.Rad2Deg;

        print(x + "--" + angle);




    }

    private void Demo03()
    {
        //将点从自身坐标系,转换到世界坐标系中
        //自身坐标系:原点物体的轴心点
        //Vector3 worldPoint= this.transform.InverseTransformPoint(0, 0, 10);//我前方的十米,在世界的哪里
        //公式:sinx=b/c

        //float x = Mathf.Sin(30 * Mathf.Deg2Rad) * 10;
        //float z = Mathf.Cos(30 * Mathf.Deg2Rad) * 10;
        //Vector3 worldPoint = this.transform.InverseTransformPoint(x, 0, z);


        ////练习:计算物体右前方30度,10米远坐标
        //Debug.DrawLine(this.transform.position, worldPoint);
        //print(worldPoint);

        //计算物体 左前方60度 20米 坐标

        float x = Mathf.Sin(-60 * Mathf.Deg2Rad) * 20;
        float z = Mathf.Cos(-60 * Mathf.Deg2Rad) * 20;
        Vector3 worldPoint = this.transform.InverseTransformPoint(x, 0, z);
        //Debug.DrawLine(this.transform.position, worldPoint);
       // print(worldPoint);
        
        //







    }



}
