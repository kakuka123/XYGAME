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
            //1ŷ����-->��Ԫ��
            //Quaternion.Euler(ŷ����)//������������xyz

            //2��Ԫ��-->ŷ����
            Quaternion qt = this.transform.rotation;
            Vector3 euler = qt.eulerAngles;

            //3.��/��  ����:�Ƕ�,��ת��
            //Quaternion.Euler(0, 50, 0); //��ͬ���������,�����ỹҪ����д
            Quaternion.AngleAxis(50,Vector3.up);//�����������
        }


        if (GUILayout.Button("LookRotation"))
        {

            //z��ָ��һ������
            //��ǰ����ע��tf��ת
            Vector3 dir = tf.position - this.transform.position;
            //��ǰ���� ע����ת
            this.transform.rotation=Quaternion.LookRotation(dir);
        }

        if (GUILayout.RepeatButton("RotateTowards"))
        {
            Quaternion dir = Quaternion.LookRotation(tf.position - this.transform.position);
            //��ֵ��ת
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);
            //������ת
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, dir, 0.1f);
        }

        if (GUILayout.RepeatButton("Angle"))
        {
            Quaternion dir = Quaternion.Euler(0, 90, 0);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);//�ӵ�ǰ��ת�Ƕ�ת��Ŀ��Ƕ�,����0.1f
            //�����ǰ��ת�Ƕ� �ӽ�Ŀ����ת�Ƕ�
            if (Quaternion.Angle(this.transform.rotation, dir) < 1)
            {
                this.transform.rotation = dir;
            }

            //����ת ������ͬһ
            //transform.rotation = Quaternion.identity;

        }
        if (GUILayout.RepeatButton("Angle2"))
        {
            //8.x��ע����ת
            //this.transform.right = tf.position - this.transform.position;
            //x��������-->ע��Ŀ��λ�õķ���
            Quaternion.FromToRotation(Vector3.right, tf.position - this.transform.position);
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (GUILayout.RepeatButton("FromToRotation"))
        {
            //x��ע����ת t1
            //this.transform.right = tf.position - this.transform.position;
            //x��������-->ע��Ŀ��λ�õķ���
            Quaternion dir = Quaternion.FromToRotation(Vector3.right, this.transform.position);
            this.transform.rotation = dir;

        }

   



    }
}
