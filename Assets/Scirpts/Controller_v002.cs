using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_v002 : MonoBehaviour
{

    public float runspeed = 4;
    public float crouchspeed = 1.5f;
    public float rotationspeed = 10;//转速很严格12为最好,不然会抖动 
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isStand)//站立状态
            {
                isRun = true;//跑动true
                anim.SetBool("IsRun", true);//奔跑
                anim.SetBool("IsStoHide", false);//避免idle_aim-->crouch
                anim.SetBool("IsRtoHide", false);//避免idle_aim-->crouch
            }
            else//非站立状态,下蹲移动
            {
                isCrouchMove = true;
                anim.SetBool("IsCrouchMove", true);//下蹲移动
                anim.SetBool("IsRtoHide", true);//下蹲移动
                anim.SetBool("IsStoHide", true);//下蹲移动
            }
        }


        else//松开wasd
        {
            if (isStand)//回到自然待机
            {
                isRun = false;
                anim.SetBool("IsRun", false);//停跑
            }
            else//回到蹲伏静止
            {
                isCrouchMove = false;
                anim.SetBool("IsCrouchMove", false);//下蹲待机
            }

        }


        //下蹲or站立 空格切换
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStand)//站立-->蹲下 待机or奔跑or待机瞄准or奔跑瞄准
            {
                if (isAim)//瞄准
                {
                    if (isRun)//奔跑瞄准-->蹲下移动
                    {
                        anim.SetBool("IsRtoHide", true);//避免串了动作
                        anim.SetBool("IsCrouch", true);//蹲下
                    }
                    else//站立瞄准
                    {
                        anim.SetBool("IsStoHide", true);//避免串了动作
                        anim.SetBool("IsCrouch", true);//蹲下
                    }
                }
                else//未瞄准
                {
                    if (isRun)//仅奔跑
                    {
                        anim.SetBool("IsRtoHide", true);//避免串了动作
                        anim.SetBool("IsCrouch", true);//蹲下
                        
                    }
                    else//仅站立
                    {
                        anim.SetBool("IsCrouch", true);//蹲下
                        anim.SetBool("IsStoHide", true);//避免串了动作
                    }

                }
                isStand = false;
                isCrouch = true;
                isHide = true;
                isRun = false;
            }
            else//蹲下-->站立  蹲下or蹲下移动or蹲下瞄准or蹲下移动瞄准
            {
                if (isAim)//瞄准状态
                {
                    if (isCrouchMove)//蹲移瞄准
                    {
                        anim.SetBool("IsCrouch", false);//蹲下
                        anim.SetBool("IsRtoHide", false);//避免串了动作
                    }
                    else//蹲下瞄准
                    {
                        anim.SetBool("IsCrouch", false);//蹲下
                        anim.SetBool("IsStoHide", false);//避免串了动作
                    }
  
                }
                else//未瞄准
                {
                    if (isCrouchMove)//蹲下移动
                    {
                        anim.SetBool("IsCrouch", false);//蹲下
                        //anim.SetBool("IsRtoHide", false);//避免串了动作
                    }
                    else//仅蹲下
                    {
                        anim.SetBool("IsCrouch", false);//蹲下
                        anim.SetBool("IsRtoHide", false);//避免串了动作     
                    }

                }
                isStand = true;
                isCrouch = false;
                isHide = false;
                isCrouchMove = false;
            }
        }

        if (Input.GetMouseButton(1))//当按住鼠标右键时 进入瞄准状态
        {
            isAim = true;
            if (isStand)//站立状态 直接瞄准
            {
                anim.SetBool("IsAim", true);//瞄准动作
                anim.SetBool("IsStoHide", false);//避免串了动作
            }
            else
            {
                anim.SetBool("IsAim", false);//瞄准动作
            }

        }
        if (Input.GetMouseButtonUp(1))//松开鼠标右键时 取消瞄准状态
        {
            isAim = false;
            if (isStand)//站立状态 取消瞄准
            {
                anim.SetBool("IsAim", false);//瞄准动作
                anim.SetBool("IsStoHide", false);//避免串了动作

            }
            else
            {
                anim.SetBool("IsAim", false);//瞄准动作
            }
        }

    }

}