using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorDetection : MonoBehaviour
{
    public float attackDis;//���εİ뾶
    public float attackAngle;//���εĽǶ�

    public Transform targetTrans;//Ŀ��λ�ã�����λ�ã�

    private void Update()
    {
        float dis = Vector3.Distance(transform.position, targetTrans.position);
        float angle = Vector3.Angle(transform.forward, targetTrans.position - transform.position);

        if (dis <= attackDis && angle <= attackAngle / 2)
        {
            Debug.Log("�����η�Χ��");
        }
    }
}
