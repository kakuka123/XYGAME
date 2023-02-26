using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRotation : MonoBehaviour
{

    public float hor=0;

    public float rotateSpeed = 1;
    // Update is called once per frame
    private void FixUpdate()
    {
        //���ϣ�������Զ��尴��
        //����������ƶ���ת
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if(x!=0||x!=0)
        RotateView( x, y);

    }

    private void RotateView( float x,  float y)
    {
        x *= rotateSpeed;
        y *= rotateSpeed;

        //��Y����ת
        this.transform.Rotate(-y, 0, 0);
        //������ת,��Ҫ����������ϵY��
        this.transform.Rotate(0, x, 0, Space.World);
    }
}
