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
        //�Ƕ�->����:����=�Ƕ�*PI/180
        //float d1 = 30;
        //float r1 = d1 * Mathf.PI / 180;
        //float r2 = d1 * Mathf.Deg2Rad;
        //print(r1 + "--" + r2);
        //����->�Ƕ�:�Ƕ�=����*180/PI
        //float r1 = 1;
        //float d1 = r1 * 180 / Mathf.PI;
        //float d2 = r1 * Mathf.Rad2Deg;
        //print(d1 + "--" + d2);
    }
    private void Demo02()
    {
        //��֪�Ƕ�x �߳�b
        //��:�߳�a
        //��ʽ:a=tan x * b
        float x = 50, b = 20;
        float a = Mathf.Tan(x * Mathf.Deg2Rad) * b;


        //��֪�߳�a �߳�b
        //��Ƕ�x
        //��ʽ: x=arctan a/b
        float angle = Mathf.Atan(a / b)*Mathf.Rad2Deg;

        print(x + "--" + angle);




    }

    private void Demo03()
    {
        //�������������ϵ,ת������������ϵ��
        //��������ϵ:ԭ����������ĵ�
        //Vector3 worldPoint= this.transform.InverseTransformPoint(0, 0, 10);//��ǰ����ʮ��,�����������
        //��ʽ:sinx=b/c

        //float x = Mathf.Sin(30 * Mathf.Deg2Rad) * 10;
        //float z = Mathf.Cos(30 * Mathf.Deg2Rad) * 10;
        //Vector3 worldPoint = this.transform.InverseTransformPoint(x, 0, z);


        ////��ϰ:����������ǰ��30��,10��Զ����
        //Debug.DrawLine(this.transform.position, worldPoint);
        //print(worldPoint);

        //�������� ��ǰ��60�� 20�� ����

        float x = Mathf.Sin(-60 * Mathf.Deg2Rad) * 20;
        float z = Mathf.Cos(-60 * Mathf.Deg2Rad) * 20;
        Vector3 worldPoint = this.transform.InverseTransformPoint(x, 0, z);
        //Debug.DrawLine(this.transform.position, worldPoint);
       // print(worldPoint);
        
        //







    }



}
