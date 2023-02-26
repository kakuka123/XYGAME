using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class VectorDemo : MonoBehaviour
{
    public Transform t1,t2,t3;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Demo05();
    }

    //模长
    private void Demo01()
    {
        Vector3 pos = this.transform.position;
        //向量的模长  pow乘方,sqrt开平方
        float m01 = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2) + Mathf.Pow(pos.z, 2));
        //API获取向量的模长
        float m02 = pos.magnitude;
        //两点间间距
        float m03 = Vector3.Distance(Vector3.zero, pos);
        //用占位符输出
        Debug.LogFormat("{0}--{1}--{2}", m01, m02, m03);

        Debug.DrawLine(Vector3.zero,pos);
    }

    //方向
    private void Demo02()
    {
        Vector3 pos = this.transform.position;
        //向量模长
        Vector3 n01 = pos / pos.magnitude;
        //api获取向量的方向,归一化 标准化-->计算单位向量
        Vector3 n02 = pos.normalized;

        Debug.DrawLine(Vector3.zero, pos);
        Debug.DrawLine(Vector3.zero, n02,Color.red);
    }

    //向量计算
    private void Demo03()
    {
        Vector3 relativeDirection = t1.position - t2.position;
        //方向:指向被减向量(前面的)  a-b  指向a
        //大小:两点间距
        //注意:实际位置要平移到世界坐标原点
        //Debug.DrawLine(Vector3.zero, relativeDirection);
        //Debug.DrawLine(t1.position, t2.position);
        //t3沿着方向移动

        if (Input.GetKey(KeyCode.A))
            //relativeDirection.normalized:获取方向,不受距离对速度造成的影响
            //t3.Translate(relativeDirection.normalized);
            t3.position = t3.position + relativeDirection.normalized;//功能同translate
        Debug.DrawLine(Vector3.zero, relativeDirection);

    }

    private void Demo04()
    {
        //向量+-向量
        //向量*/数字
        //计算点乘,向量cross dot向量
        float dot = Vector3.Dot(t1.position.normalized, t2.position.normalized);
        //dot 两个向量夹角 cos值
        //计算夹角
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        angle = Vector3.Angle(t1.position, t2.position);
        Debug.DrawLine(t1.transform.position, Vector3.zero);
        Debug.DrawLine(t2.transform.position, Vector3.zero);

        //如果夹角大于60度
        //if (angle>60) 
        if (dot<0.5f)//60度的cos值不用算夹角 直接用点乘结果判定
        {
            print("大于60度");
        }
        //计算叉乘,判断t1,在t2的左边 还是右边
        Vector3 cross= Vector3.Cross(t1.position, t2.position);
        if (cross.y<0)
        {
            angle = 360 - angle;
        }
        //绘制垂直向量
        Debug.DrawLine(Vector3.zero, cross, Color.red);
      
    }
    private void Demo05()
    {
        /*
        t1是敌人
        t2是我方
        绘制:敌人正前方左右60度是视野范围
        绘制:t1,t2连线
        


        */
        Vector3 abc = t1.position - t2.position;
        Debug.DrawLine(t1.position, t2.position, Color.yellow);

        float x = Mathf.Sin(-30 * Mathf.Deg2Rad) * 10;
        float z = Mathf.Cos(-30 * Mathf.Deg2Rad) * 10;
        Vector3 enemy = t1.transform.TransformPoint(x, 0.5f, z);
        Vector3 enemy2 = t1.transform.TransformPoint(-x, 0.5f, z);
        Vector3 sight = t1.transform.TransformPoint(0, 0.5f, 10f);


        Debug.DrawLine(t1.position, enemy);
        Debug.DrawLine(t1.position, enemy2);
        Debug.DrawLine(t1.position,sight);






        
    }

}
