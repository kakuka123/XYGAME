using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Controll_Test : MonoBehaviour
{
    //private CharacterController controller;
    //public float moveSpeed = 5f;
    //public float rotateSpeed = 1f;

    public float speed;
    public float rotationspeed;
    private void Start()
    {
        //controller = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        //moveLikeWow();
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        move.Normalize();
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (move!=Vector3.zero)
        {
            //transform.forward = move;
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed*Time.deltaTime);

        }


    }

    private void moveLikeWow()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //var move = new Vector3(h, 0, v);
        //controller.Move(move * moveSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(Vector3.forward);

   


    }


}