using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentDetection : MonoBehaviour
{
    public string playerTag = "Player";
    public Transform playerTf;
    private float radius;



    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerGO=GameObject.FindWithTag(playerTag);
        playerTf = PlayerGO.transform;
        radius = PlayerGO.GetComponent<CapsuleCollider>().radius;

    }
    private Vector3 leftTangent, rightTangent;
    //计算切点
    private void CalculateTangent()
    {
        //主角到爆炸点向量
        Vector3 playerToExplosion= this.transform.position - playerTf.position;
        //转变为单位向量,长度为半径
        Vector3 playerToExplosionDirection = playerToExplosion.normalized * radius;
        //反余弦计算向量夹角 转90度
        float angle = Mathf.Acos(radius / playerToExplosion.magnitude)*Mathf.Rad2Deg;
        //左右转90度
        leftTangent = playerTf.position + Quaternion.Euler(0, -angle, 0) * playerToExplosionDirection;
        rightTangent= playerTf.position + Quaternion.Euler(0, angle, 0) * playerToExplosionDirection;

    }
    public void Dection()
    {
        CalculateTangent();
        Debug.DrawLine(this.transform.position, leftTangent);
        Debug.DrawLine(this.transform.position, rightTangent);
        if (Vector3.Distance(this.transform.position,playerTf.position)<10)
        {
            Debug.DrawLine(this.transform.position, leftTangent,Color.red);
            Debug.DrawLine(this.transform.position, rightTangent,Color.red);
        }

    }





    // Update is called once per frame
    void Update()
    {
        Dection();
        //Debug.DrawLine(this.transform.position, playerTf.position);
        //    Vector3 worldpoint = new Vector3 (0,0,0);
        //    distance = e1.position - p1.position;
        //    //炸弹到原点的线
        //    Debug.DrawLine(e1.position, worldpoint);
        //    //角色到原点的线
        //    Debug.DrawLine(p1.position, worldpoint);
        //    //炸弹到角色的连线
        //    Debug.DrawLine(e1.position, p1.position);
        //    //炸弹到角色的切线1
        //    Debug.DrawLine(e1.position, p1.position + new Vector3 (-0.5f, 0, 0));

        //炸弹到角色的切线2



        //
        //Debug.DrawLine(p1.position + e1.position,worldpoint+e1.position,Color.red);

    }
}
