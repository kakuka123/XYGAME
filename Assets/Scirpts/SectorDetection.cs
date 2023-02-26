using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorDetection : MonoBehaviour
{
    public float attackDis;//扇形的半径
    public float attackAngle;//扇形的角度

    public Transform targetTrans;//目标位置（敌人位置）

    private void Update()
    {
        float dis = Vector3.Distance(transform.position, targetTrans.position);
        float angle = Vector3.Angle(transform.forward, targetTrans.position - transform.position);

        if (dis <= attackDis && angle <= attackAngle / 2)
        {
            Debug.Log("在扇形范围内");
        }
    }
}
