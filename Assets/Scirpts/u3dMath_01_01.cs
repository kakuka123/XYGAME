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
        //狙击镜 二阶
        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
            //拉远60
            if (isFar)
            {
                camera.fieldOfView = 60;
            }
            //拉近20
            else
            {
                camera.fieldOfView = 20;
            }
        }



    }
    void Update3()
    {

        //狙击镜 二阶 渐变
        //狙击镜 二阶
        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
        }

        //拉远60
        if (isFar)
        {
            if (camera.fieldOfView < 60)
                camera.fieldOfView += 2;
        }
        //拉近20
        else
        {
            if (camera.fieldOfView > 20)
                camera.fieldOfView -= 2;
        }

    }

    void Update4()
    {
        //狙击镜 二阶 渐变
        //狙击镜 二阶
        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
        }

        //拉远60
        if (isFar)
        {
           camera.fieldOfView=Mathf.Lerp(camera.fieldOfView, 60, 0.1f);//永远接近不能达到
            if (Mathf.Abs(camera.fieldOfView - 60) < 0.1f)//绝对值小于0.1时,停止计算
            {
                camera.fieldOfView = 60;
            }            
        }
        //拉近20
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
        //狙击镜 N阶 渐变
        //狙击镜 N阶
        if (Input.GetMouseButtonDown(1))
        {
            //index = index < zoomlevel.Length-1 ? index + 1 : 0;//三元表达式,?前为条件,满足则冒号前,不满足则冒号后
            index = (index + 1) % zoomlevel.Length;
        }

        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomlevel[index], 0.1f);//永远接近不能达到
        if (Mathf.Abs(camera.fieldOfView - zoomlevel[index]) < 0.1f)//绝对值小于0.1时,停止计算
        {
            camera.fieldOfView = zoomlevel[index];
        }


    }
}
