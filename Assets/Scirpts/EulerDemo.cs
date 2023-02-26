using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerDemo : MonoBehaviour
{
    public Vector3 euler;

    private void OnGUI()
    {
        euler = this.transform.eulerAngles;
        if (GUILayout.RepeatButton("沿x轴旋转"))
        {
            Vector3 pos = this.transform.position;
            //位置,有方向,(从世界原点指向当前位置),有大小(当前位置到世界原点间距)
            //向量的x,y,z  表示各个轴向上的有向位移

            Vector3 euler = this.transform.eulerAngles;
            //注意:欧拉角,没有方向,没有大小的概念
            //因为3维向量,包含x,y,z,所以在unity中,欧拉角的数据类型为Vector3
            //欧拉角对的x.y.z,表示各个轴向上的旋转角度
            //各分量相加 欧拉角的x增加1度
            this.transform.eulerAngles += new Vector3(1, 0, 0);


        }

        if (GUILayout.RepeatButton("沿y轴旋转"))
        {
            //this.transform.eulerAngles += new Vector3(0, 1, 0);
            this.transform.eulerAngles += Vector3.up;
        } 
        if (GUILayout.RepeatButton("沿z轴旋转"))
        {
            //this.transform.eulerAngles += new Vector3(0, 0, 1);
            this.transform.eulerAngles += Vector3.forward;

        }


    }


}
