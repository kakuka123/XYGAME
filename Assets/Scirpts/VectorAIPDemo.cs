using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorAIPDemo : MonoBehaviour
{
    //public Transform t1;
    //public Vector3 planeNorm;
    public AnimationCurve curve;
    private float x;
    public float duration=5;//ʱ��
    private Vector3 targetPos = new Vector3(0, 0, 10);

    private void Update()
    {
        //Vector3 vect = new Vector3(0, 0, 10);
        //Vector3 norm = vect.normalized;//����һ��0 0 1
        //vect.Normalize();//��vect����Ϊ0 0 1
        //ͶӰ
        //Vector3 result= Vector3.ProjectOnPlane(t1.position, planeNorm);
        //Debug.DrawLine(Vector3.zero, result,Color.red);
        //Debug.DrawLine(Vector3.zero, t1.position);


    }


    private void OnGUI()
    {
        if (GUILayout.RepeatButton("MoveTowards"))
        {
            //����ǰ�����ƶ��� 0 0 10
            //�����ƶ� ���Ե���Ŀ���
            //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.1f);
            //�ȿ쵽�� �Ҳ��ܵ���Ŀ��� ���޽ӽ�
            //��㲻�̶� �յ�ͱ����̶�
            this.transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, 1f);

        }
        if (GUILayout.RepeatButton("Lerp"))
        {
            x += Time.deltaTime/duration;//duration�Ƕ��� ���Ƕ����뵽��
            //����ǰ�����ƶ��� 0 0 10
            //�����ƶ� ���Ե���Ŀ���
            //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.1f);
            //��Ȼ�˶� ���̶� �յ�̶� �����������߱仯
            //this.transform.position = Vector3.Lerp(Vector3.zero, targetPos, curve.Evaluate(x));
            this.transform.position = Vector3.LerpUnclamped(Vector3.zero, targetPos, curve.Evaluate(x));

        }
    }



}
