using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Controll : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed=10f;    
    public float rotateSpeed=1f;
    //public float turnSpeed=8f;

    public Vector3 upwardVector;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //MoveLikeWow();
        //MoveLikeTopDown2();
        player_Controll();
    }
    private void MoveLikeWow()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var move = transform.forward * moveSpeed *v* Time.deltaTime;
        controller.Move(move);
        transform.Rotate(Vector3.up,h*rotateSpeed);



    }
    private void MoveLikeTopDown()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0, v).normalized;
        var move = direction * moveSpeed * Time.deltaTime;
        controller.Move(move);
        var playerpoint = Camera.main.WorldToScreenPoint(transform.position);
        var point = Input.mousePosition - playerpoint;
        var angle = Mathf.Atan2(point.x, point.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
        
    }
    private void MoveLikeTopDown2()//没有鼠标转向
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var move_h = transform.right * moveSpeed * h * Time.deltaTime;
        var move_v = transform.forward * moveSpeed * v * Time.deltaTime;
        controller.Move(move_h);
        controller.Move(move_v);
        bool Actor_IsRun_h = Mathf.Abs(move_h.x) > 0;
        bool Actor_IsRun_v = Mathf.Abs(move_v.z) > 0;
        var anim = GetComponent<Animator>();
        //Vector3 m = new Vector3(h, 0f, v);      // 创建控制输入向量m
        //Vector3 turnForward = Vector3.RotateTowards(transform.forward, m, turnSpeed * Time.deltaTime, 0f);
        //transform.rotation = Quaternion.LookRotation(turnForward);	// Vector3转成4元数Quaternion



        if (Actor_IsRun_h == true|| Actor_IsRun_v== true)
        {            
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }


    private void player_Controll()
    {
        var anim = GetComponent<Animator>();
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h)>0|| Mathf.Abs(v) > 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }




        if (controller.isGrounded)
        {
            moveDirection = new Vector3(h, 0.0f, v);
            moveDirection *= speed;
            //跳跃功能
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    upwardVector.y = jumpSpeed;
            //}
        }
        else
        {
            upwardVector.y -= gravity * Time.deltaTime;
        }
        controller.Move((moveDirection + upwardVector) * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(moveDirection);


        //瞄准动作
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("IsAim", true);
        }
        else
        {
            anim.SetBool("IsAim", false);
        }

        //下蹲-按住空格
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    anim.SetBool("IsCrouch", true);
        //}
        //else
        //{
        //    anim.SetBool("IsCrouch", false);
        //}

        //下蹲-站立 空格切换
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (anim.GetBool("IsCrouch") == false)
            {
                anim.SetBool("IsCrouch", true);
            }
            else
            {
                anim.SetBool("IsCrouch", false);
            }
            
        }

     
   
   


        //下蹲行走




    }

}