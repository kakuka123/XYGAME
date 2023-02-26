using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public GameObject flashGo;
    private float hideTimer;
    public float displayTime = 0.3f;
    public void DisplayFlash()
    {
        flashGo.SetActive(true);
        //����ʱ���������
        hideTimer = Time.time + displayTime;
    }



    // Update is called once per frame
    void Update()
    {
        //����������,�ҵ�������ʱ��
        if (flashGo.activeInHierarchy&&Time.time>=hideTimer)
        {
            flashGo.SetActive(false);
        }

        //����

        if (Input.GetMouseButtonDown(0))
        {
            DisplayFlash();
        }
        
    }
}
