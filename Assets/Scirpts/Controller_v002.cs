using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_v002 : MonoBehaviour
{

    public float runspeed = 4;
    public float crouchspeed = 1.5f;
    public float rotationspeed = 10;//ת�ٺ��ϸ�12Ϊ���,��Ȼ�ᶶ�� 
    public bool isStand = true;
    public bool isAim = false;
    public bool isRun = false;
    public bool isCrouch = false;
    public bool isCrouchMove = false;
    public bool isHide = false;
    public bool isHit = false;
    public bool isDead = false;
    public bool isHitFly = false;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    public void movement()//�ƶ���ת��
    {
        //�ƶ��Ļ���
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        move.Normalize();//������׼�� ��֤���������ٶ�һ��

        if (isStand)
        {
            transform.Translate(move * runspeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(move * crouchspeed * Time.deltaTime, Space.World);
        }
        var anim = GetComponent<Animator>();
        //�ƶ�������ɫת��
        if (move != Vector3.zero)//�����ɫ���Ǿ�ֹ����
        {
            //����һ����Ԫ��
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);//ת���ƶ������ķ��� ת��Y��
            //��ɫ������Ԫ��ת��
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationspeed * Time.deltaTime);//��ǰ����,Ŀ�귽��,ת���ٶ�
        }
        //��������
        //�ƶ� ���� �¶��ƶ�
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isStand)//վ��״̬
            {
                isRun = true;//�ܶ�true
                anim.SetBool("IsRun", true);//����
                anim.SetBool("IsStoHide", false);//����idle_aim-->crouch
                anim.SetBool("IsRtoHide", false);//����idle_aim-->crouch
            }
            else//��վ��״̬,�¶��ƶ�
            {
                isCrouchMove = true;
                anim.SetBool("IsCrouchMove", true);//�¶��ƶ�
                anim.SetBool("IsRtoHide", true);//�¶��ƶ�
                anim.SetBool("IsStoHide", true);//�¶��ƶ�
            }
        }


        else//�ɿ�wasd
        {
            if (isStand)//�ص���Ȼ����
            {
                isRun = false;
                anim.SetBool("IsRun", false);//ͣ��
            }
            else//�ص��׷���ֹ
            {
                isCrouchMove = false;
                anim.SetBool("IsCrouchMove", false);//�¶״���
            }

        }


        //�¶�orվ�� �ո��л�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStand)//վ��-->���� ����or����or������׼or������׼
            {
                if (isAim)//��׼
                {
                    if (isRun)//������׼-->�����ƶ�
                    {
                        anim.SetBool("IsRtoHide", true);//���⴮�˶���
                        anim.SetBool("IsCrouch", true);//����
                    }
                    else//վ����׼
                    {
                        anim.SetBool("IsStoHide", true);//���⴮�˶���
                        anim.SetBool("IsCrouch", true);//����
                    }
                }
                else//δ��׼
                {
                    if (isRun)//������
                    {
                        anim.SetBool("IsRtoHide", true);//���⴮�˶���
                        anim.SetBool("IsCrouch", true);//����
                        
                    }
                    else//��վ��
                    {
                        anim.SetBool("IsCrouch", true);//����
                        anim.SetBool("IsStoHide", true);//���⴮�˶���
                    }

                }
                isStand = false;
                isCrouch = true;
                isHide = true;
                isRun = false;
            }
            else//����-->վ��  ����or�����ƶ�or������׼or�����ƶ���׼
            {
                if (isAim)//��׼״̬
                {
                    if (isCrouchMove)//������׼
                    {
                        anim.SetBool("IsCrouch", false);//����
                        anim.SetBool("IsRtoHide", false);//���⴮�˶���
                    }
                    else//������׼
                    {
                        anim.SetBool("IsCrouch", false);//����
                        anim.SetBool("IsStoHide", false);//���⴮�˶���
                    }
  
                }
                else//δ��׼
                {
                    if (isCrouchMove)//�����ƶ�
                    {
                        anim.SetBool("IsCrouch", false);//����
                        //anim.SetBool("IsRtoHide", false);//���⴮�˶���
                    }
                    else//������
                    {
                        anim.SetBool("IsCrouch", false);//����
                        anim.SetBool("IsRtoHide", false);//���⴮�˶���     
                    }

                }
                isStand = true;
                isCrouch = false;
                isHide = false;
                isCrouchMove = false;
            }
        }

        if (Input.GetMouseButton(1))//����ס����Ҽ�ʱ ������׼״̬
        {
            isAim = true;
            if (isStand)//վ��״̬ ֱ����׼
            {
                anim.SetBool("IsAim", true);//��׼����
                anim.SetBool("IsStoHide", false);//���⴮�˶���
            }
            else
            {
                anim.SetBool("IsAim", false);//��׼����
            }

        }
        if (Input.GetMouseButtonUp(1))//�ɿ�����Ҽ�ʱ ȡ����׼״̬
        {
            isAim = false;
            if (isStand)//վ��״̬ ȡ����׼
            {
                anim.SetBool("IsAim", false);//��׼����
                anim.SetBool("IsStoHide", false);//���⴮�˶���

            }
            else
            {
                anim.SetBool("IsAim", false);//��׼����
            }
        }

    }

}