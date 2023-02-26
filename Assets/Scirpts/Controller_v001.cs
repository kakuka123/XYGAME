using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_v001 : MonoBehaviour
{
    public float runspeed = 5;
    public float crouchspeed = 1.5f;
    public float rotationspeed = 10;//转速很严格12为最好,不然会抖动 
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

    public void movement()//移动和转动
    {
        //移动的基础
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        move.Normalize();//向量标准化 保证各个方向速度一致

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
        //移动触发角色转向
        if (move != Vector3.zero)//如果角色不是静止不动
        {
            //创造一个四元数
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);//转向移动向量的方向 转动Y轴
            //角色根据四元数转动
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationspeed * Time.deltaTime);//当前方向,目标方向,转动速度
        }
        //动作代码
        //移动 待机 下蹲移动
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isStand)//站立状态
            {
                isRun = true;//跑动true
                anim.SetBool("IsRun", true);//站立奔跑
            }
            else//非站立状态,下蹲移动
            {
                isCrouchMove = true;
                anim.SetBool("IsCrouchMove", true);//下蹲移动
            }
        }
        else//松开wasd
        {
            if (isStand)//回到自然待机
            {
                isRun = false;
                anim.SetBool("IsRun", false);
            }
            else//回到蹲伏静止
            {
                anim.SetBool("IsCrouchMove", false);//下蹲待机
            }
            
        }

        //下蹲or站立 空格切换
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStand)//站立-->蹲伏(无论是否在瞄准)
            {
                    isStand = false;//停止站立
                    anim.SetBool("IsStoHide", true);//瞄准-->蹲伏隐藏true
                    anim.SetBool("IsCrouch", true);//站立待机-->蹲伏true
                    anim.SetBool("IsCrouchMove", false);
                if (isRun&&isAim)//如果是跑动瞄准状态 则变为蹲伏移动
                {
                    anim.SetBool("IsRtoHide", true);//瞄准-->蹲伏隐藏true
                    anim.SetBool("IsCrouch", true);//站立待机-->蹲伏true
                }
            }

            else//蹲伏-->站立 先判断是否瞄准  
            {
                if (isAim)//瞄准:蹲伏-->站立瞄准
                {
                    
                    anim.SetBool("IsStoHide", false);//切换站立瞄准动作
                    isStand = true;//状态:站立
                    if (isCrouchMove )//如果是下蹲移动状态 则站立奔跑
                    {
                        anim.SetBool("IsRtoHide", false);
                        anim.SetBool("IsCrouch", false);
                    }
                }
                else//未瞄准:蹲伏--> 自然待机
                {
                    
                    anim.SetBool("IsCrouch", false);//切换站立动作
                    isStand = true;//状态:站立
                    //anim.SetBool("IsCrouch", false);//切换站立动作                
                    //print("站立状态");

                    if (isCrouchMove)
                    {
                        anim.SetBool("IsCrouch", false);
                        anim.SetBool("IsCrouchMove", false);
                    }

                }
         
            }

       



        }

        //瞄准

        if (Input.GetMouseButton(1))//当按住鼠标右键时 进入瞄准状态
        {
            if (isStand)//站立状态 直接瞄准
            {
                isAim = true;
                anim.SetBool("IsAim", true);//瞄准动作
                anim.SetBool("IsCrouch", false);//解除蹲伏
                anim.SetBool("IsStoHide", false);//解除隐藏
            }
            else//蹲伏状态 不做瞄准动作,但是判定在瞄准状态
            {
                isAim = true;
                anim.SetBool("IsAim", true);
            }
            
        }
        if (Input.GetMouseButtonUp(1))//松开鼠标右键时
        {
            if (isStand)//瞄准站立-->自然待机
            {
                isAim = false;
                anim.SetBool("IsAim", false);//返回待机
            }
            else//蹲伏状态 不做瞄准动作,取消在瞄准状态
            {
                isAim = false;
                anim.SetBool("IsAim", false);
            }
            
        }
    }






}
