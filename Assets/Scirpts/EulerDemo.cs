using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerDemo : MonoBehaviour
{
    public Vector3 euler;

    private void OnGUI()
    {
        euler = this.transform.eulerAngles;
        if (GUILayout.RepeatButton("��x����ת"))
        {
            Vector3 pos = this.transform.position;
            //λ��,�з���,(������ԭ��ָ��ǰλ��),�д�С(��ǰλ�õ�����ԭ����)
            //������x,y,z  ��ʾ���������ϵ�����λ��

            Vector3 euler = this.transform.eulerAngles;
            //ע��:ŷ����,û�з���,û�д�С�ĸ���
            //��Ϊ3ά����,����x,y,z,������unity��,ŷ���ǵ���������ΪVector3
            //ŷ���ǶԵ�x.y.z,��ʾ���������ϵ���ת�Ƕ�
            //��������� ŷ���ǵ�x����1��
            this.transform.eulerAngles += new Vector3(1, 0, 0);


        }

        if (GUILayout.RepeatButton("��y����ת"))
        {
            //this.transform.eulerAngles += new Vector3(0, 1, 0);
            this.transform.eulerAngles += Vector3.up;
        } 
        if (GUILayout.RepeatButton("��z����ת"))
        {
            //this.transform.eulerAngles += new Vector3(0, 0, 1);
            this.transform.eulerAngles += Vector3.forward;

        }


    }


}
