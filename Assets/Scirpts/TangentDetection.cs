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
    //�����е�
    private void CalculateTangent()
    {
        //���ǵ���ը������
        Vector3 playerToExplosion= this.transform.position - playerTf.position;
        //ת��Ϊ��λ����,����Ϊ�뾶
        Vector3 playerToExplosionDirection = playerToExplosion.normalized * radius;
        //�����Ҽ��������н� ת90��
        float angle = Mathf.Acos(radius / playerToExplosion.magnitude)*Mathf.Rad2Deg;
        //����ת90��
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
        //    //ը����ԭ�����
        //    Debug.DrawLine(e1.position, worldpoint);
        //    //��ɫ��ԭ�����
        //    Debug.DrawLine(p1.position, worldpoint);
        //    //ը������ɫ������
        //    Debug.DrawLine(e1.position, p1.position);
        //    //ը������ɫ������1
        //    Debug.DrawLine(e1.position, p1.position + new Vector3 (-0.5f, 0, 0));

        //ը������ɫ������2



        //
        //Debug.DrawLine(p1.position + e1.position,worldpoint+e1.position,Color.red);

    }
}
