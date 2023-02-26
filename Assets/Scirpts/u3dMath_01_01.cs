using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class u3dMath_01_01 : MonoBehaviour
{
    public bool isDown;
    private bool isFar=true;
    private Camera camera;
    public float[] zoomlevel;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update2()
    {
        isDown = Input.GetMouseButton(0);
        if (Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("CD");
        }
        //�ѻ��� ����
        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
            //��Զ60
            if (isFar)
            {
                camera.fieldOfView = 60;
            }
            //����20
            else
            {
                camera.fieldOfView = 20;
            }
        }



    }
    void Update3()
    {

        //�ѻ��� ���� ����
        //�ѻ��� ����
        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
        }

        //��Զ60
        if (isFar)
        {
            if (camera.fieldOfView < 60)
                camera.fieldOfView += 2;
        }
        //����20
        else
        {
            if (camera.fieldOfView > 20)
                camera.fieldOfView -= 2;
        }

    }

    void Update4()
    {
        //�ѻ��� ���� ����
        //�ѻ��� ����
        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
        }

        //��Զ60
        if (isFar)
        {
           camera.fieldOfView=Mathf.Lerp(camera.fieldOfView, 60, 0.1f);//��Զ�ӽ����ܴﵽ
            if (Mathf.Abs(camera.fieldOfView - 60) < 0.1f)//����ֵС��0.1ʱ,ֹͣ����
            {
                camera.fieldOfView = 60;
            }            
        }
        //����20
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 20, 0.1f);
            if (Mathf.Abs(camera.fieldOfView - 20) < 0.1f)
            {
                camera.fieldOfView = 20;
            }
        }

    }

    void Update()
    {
        //�ѻ��� N�� ����
        //�ѻ��� N��
        if (Input.GetMouseButtonDown(1))
        {
            //index = index < zoomlevel.Length-1 ? index + 1 : 0;//��Ԫ���ʽ,?ǰΪ����,������ð��ǰ,��������ð�ź�
            index = (index + 1) % zoomlevel.Length;
        }

        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomlevel[index], 0.1f);//��Զ�ӽ����ܴﵽ
        if (Mathf.Abs(camera.fieldOfView - zoomlevel[index]) < 0.1f)//����ֵС��0.1ʱ,ֹͣ����
        {
            camera.fieldOfView = zoomlevel[index];
        }


    }
}
