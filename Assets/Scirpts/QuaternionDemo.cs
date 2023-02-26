using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionDemo : MonoBehaviour
{
    private Vector3 vect;



    private void OnGUI()
    {
        if (GUILayout.Button("����������ת�Ƕ�"))
        {
            Quaternion qt = new Quaternion();
            //��ת��
            Vector3 axis = Vector3.up;
            //��ת����
            float rad = 50 * Mathf.Deg2Rad;

            //qt.x = Mathf.Sin(rad/ 2) * axis.x;
            //qt.y = Mathf.Sin(rad/ 2) * axis.y;
            //qt.z = Mathf.Sin(rad/ 2) * axis.z;
            //qt.w = Mathf.Cos(rad / 2);
            //this.transform.rotation = qt;

            //ŷ����-->��Ԫ��
            this.transform.rotation = Quaternion.Euler(0, 50, 0);
         


        }

        if (GUILayout.RepeatButton("��X����ת"))
        {
            //���20�� Ҫ��Ϊ50��   ��Ҫ��Ԫ���ó˷�(20*30)�õ�
            this.transform.rotation *= Quaternion.Euler(1, 0, 0);
            //RotateҲ����Ԫ��
            //this.transform.Rotate(1,0,0);
        }


        if (GUILayout.RepeatButton("��y����ת"))
        {
            //this.transform.eulerAngles += new Vector3(0, 1, 0);
            this.transform.rotation *= Quaternion.Euler(0, 1, 0);
        }
        if (GUILayout.RepeatButton("��z����ת"))
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
            //vect���� ���ݵ�ǰ�������ת����ת
            vect = this.transform.rotation * new Vector3(0, 0, 10);
            //vect���� ��y����ת30��
            vect = Quaternion.Euler(0, 30, 0) * vect;
            //vect���� �ƶ�����ǰ����λ��
            vect = this.transform.position + vect;                  
            //�ܽ�Ϊ��������
            //vect = this.transform.position + Quaternion.Euler(0,30,0)* this.transform.rotation*new Vector3(0, 0, 10);

        }
    }





}

