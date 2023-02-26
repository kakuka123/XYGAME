using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_v001 : MonoBehaviour
{
    public float runspeed = 5;
    public float crouchspeed = 1.5f;
    public float rotationspeed = 10;//ת�ٺ��ϸ�12Ϊ���,��Ȼ�ᶶ�� 
    public bool isStand=true;
    public bool isAim=false;
    public bool isRun = false;
    public bool isCrouchMove = false;
    public bool isHide = false;


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
            isRun=false;
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
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isStand)//վ��״̬
            {
                isRun = true;//�ܶ�true
                anim.SetBool("IsRun", true);//վ������
            }
            else//��վ��״̬,�¶��ƶ�
            {
                isCrouchMove = true;
                anim.SetBool("IsCrouchMove", true);//�¶��ƶ�
            }
        }
        else//�ɿ�wasd
        {
            if (isStand)//�ص���Ȼ����
            {
                isRun = false;
                anim.SetBool("IsRun", false);
            }
            else//�ص��׷���ֹ
            {
                anim.SetBool("IsCrouchMove", false);//�¶״���
            }
            
        }

        //�¶�orվ�� �ո��л�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStand)//վ��-->�׷�(�����Ƿ�����׼)
            {
                    isStand = false;//ֹͣվ��
                    anim.SetBool("IsStoHide", true);//��׼-->�׷�����true
                    anim.SetBool("IsCrouch", true);//վ������-->�׷�true
                    anim.SetBool("IsCrouchMove", false);
                if (isRun&&isAim)//������ܶ���׼״̬ ���Ϊ�׷��ƶ�
                {
                    anim.SetBool("IsRtoHide", true);//��׼-->�׷�����true
                    anim.SetBool("IsCrouch", true);//վ������-->�׷�true
                }
            }

            else//�׷�-->վ�� ���ж��Ƿ���׼  
            {
                if (isAim)//��׼:�׷�-->վ����׼
                {
                    
                    anim.SetBool("IsStoHide", false);//�л�վ����׼����
                    isStand = true;//״̬:վ��
                    if (isCrouchMove )//������¶��ƶ�״̬ ��վ������
                    {
                        anim.SetBool("IsRtoHide", false);
                        anim.SetBool("IsCrouch", false);
                    }
                }
                else//δ��׼:�׷�--> ��Ȼ����
                {
                    
                    anim.SetBool("IsCrouch", false);//�л�վ������
                    isStand = true;//״̬:վ��
                    //anim.SetBool("IsCrouch", false);//�л�վ������                
                    //print("վ��״̬");

                    if (isCrouchMove)
                    {
                        anim.SetBool("IsCrouch", false);
                        anim.SetBool("IsCrouchMove", false);
                    }

                }
         
            }

       



        }

        //��׼

        if (Input.GetMouseButton(1))//����ס����Ҽ�ʱ ������׼״̬
        {
            if (isStand)//վ��״̬ ֱ����׼
            {
                isAim = true;
                anim.SetBool("IsAim", true);//��׼����
                anim.SetBool("IsCrouch", false);//����׷�
                anim.SetBool("IsStoHide", false);//�������
            }
            else//�׷�״̬ ������׼����,�����ж�����׼״̬
            {
                isAim = true;
                anim.SetBool("IsAim", true);
            }
            
        }
        if (Input.GetMouseButtonUp(1))//�ɿ�����Ҽ�ʱ
        {
            if (isStand)//��׼վ��-->��Ȼ����
            {
                isAim = false;
                anim.SetBool("IsAim", false);//���ش���
            }
            else//�׷�״̬ ������׼����,ȡ������׼״̬
            {
                isAim = false;
                anim.SetBool("IsAim", false);
            }
            
        }
    }






}
