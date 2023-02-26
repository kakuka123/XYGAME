using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorAIPDemo : MonoBehaviour
{
    //public Transform t1;
    //public Vector3 planeNorm;
    public AnimationCurve curve;
    private float x;
    public float duration=5;//时间
    private Vector3 targetPos = new Vector3(0, 0, 10);

    private void Update()
    {
        //Vector3 vect = new Vector3(0, 0, 10);
        //Vector3 norm = vect.normalized;//返回一个0 0 1
        //vect.Normalize();//将vect设置为0 0 1
        //投影
        //Vector3 result= Vector3.ProjectOnPlane(t1.position, planeNorm);
        //Debug.DrawLine(Vector3.zero, result,Color.red);
        //Debug.DrawLine(Vector3.zero, t1.position);


    }


    private void OnGUI()
    {
        if (GUILayout.RepeatButton("MoveTowards"))
        {
            //将当前物体移动到 0 0 10
            //匀速移动 可以到达目标点
            //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.1f);
            //先快到慢 且不能到达目标点 无限接近
            //起点不固定 终点和比例固定
            this.transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, 1f);

        }
        if (GUILayout.RepeatButton("Lerp"))
        {
            x += Time.deltaTime/duration;//duration是多少 就是多少秒到达
            //将当前物体移动到 0 0 10
            //匀速移动 可以到达目标点
            //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.1f);
            //自然运动 起点固定 终点固定 比例根据曲线变化
            //this.transform.position = Vector3.Lerp(Vector3.zero, targetPos, curve.Evaluate(x));
            this.transform.position = Vector3.LerpUnclamped(Vector3.zero, targetPos, curve.Evaluate(x));

        }
    }



}
