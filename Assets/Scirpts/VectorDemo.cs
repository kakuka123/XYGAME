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

    //ģ��
    private void Demo01()
    {
        Vector3 pos = this.transform.position;
        //������ģ��  pow�˷�,sqrt��ƽ��
        float m01 = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2) + Mathf.Pow(pos.z, 2));
        //API��ȡ������ģ��
        float m02 = pos.magnitude;
        //�������
        float m03 = Vector3.Distance(Vector3.zero, pos);
        //��ռλ�����
        Debug.LogFormat("{0}--{1}--{2}", m01, m02, m03);

        Debug.DrawLine(Vector3.zero,pos);
    }

    //����
    private void Demo02()
    {
        Vector3 pos = this.transform.position;
        //����ģ��
        Vector3 n01 = pos / pos.magnitude;
        //api��ȡ�����ķ���,��һ�� ��׼��-->���㵥λ����
        Vector3 n02 = pos.normalized;

        Debug.DrawLine(Vector3.zero, pos);
        Debug.DrawLine(Vector3.zero, n02,Color.red);
    }

    //��������
    private void Demo03()
    {
        Vector3 relativeDirection = t1.position - t2.position;
        //����:ָ�򱻼�����(ǰ���)  a-b  ָ��a
        //��С:������
        //ע��:ʵ��λ��Ҫƽ�Ƶ���������ԭ��
        //Debug.DrawLine(Vector3.zero, relativeDirection);
        //Debug.DrawLine(t1.position, t2.position);
        //t3���ŷ����ƶ�

        if (Input.GetKey(KeyCode.A))
            //relativeDirection.normalized:��ȡ����,���ܾ�����ٶ���ɵ�Ӱ��
            //t3.Translate(relativeDirection.normalized);
            t3.position = t3.position + relativeDirection.normalized;//����ͬtranslate
        Debug.DrawLine(Vector3.zero, relativeDirection);

    }

    private void Demo04()
    {
        //����+-����
        //����*/����
        //������,����cross dot����
        float dot = Vector3.Dot(t1.position.normalized, t2.position.normalized);
        //dot ���������н� cosֵ
        //����н�
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        angle = Vector3.Angle(t1.position, t2.position);
        Debug.DrawLine(t1.transform.position, Vector3.zero);
        Debug.DrawLine(t2.transform.position, Vector3.zero);

        //����нǴ���60��
        //if (angle>60) 
        if (dot<0.5f)//60�ȵ�cosֵ������н� ֱ���õ�˽���ж�
        {
            print("����60��");
        }
        //������,�ж�t1,��t2����� �����ұ�
        Vector3 cross= Vector3.Cross(t1.position, t2.position);
        if (cross.y<0)
        {
            angle = 360 - angle;
        }
        //���ƴ�ֱ����
        Debug.DrawLine(Vector3.zero, cross, Color.red);
      
    }
    private void Demo05()
    {
        /*
        t1�ǵ���
        t2���ҷ�
        ����:������ǰ������60������Ұ��Χ
        ����:t1,t2����
        


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
