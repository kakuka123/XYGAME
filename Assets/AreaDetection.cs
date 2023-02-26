using UnityEngine;

public class AreaDetection : MonoBehaviour
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
            Debug.Log("进入攻击区域");
        }
        else
        {
            Debug.Log("离开攻击区域");
        }
    }
}