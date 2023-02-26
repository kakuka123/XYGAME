using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    public float movespeed = 5f;
    public float rotatespeed = 20f;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_controll();
    }

    private void Player_controll()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var move = new Vector3(h, 0, v);
        controller.Move(move * movespeed * Time.deltaTime);

        if (move!=Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotatespeed * Time.deltaTime);
        }

        


          //var move = new Vector3(h, 0, v);
          //controller.Move(move * moveSpeed * Time.deltaTime);
          //transform.rotation = Quaternion.LookRotation(Vector3.forward);




    }

}
