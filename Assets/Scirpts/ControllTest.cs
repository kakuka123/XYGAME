using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllTest : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0, v).normalized;
        var move = direction * moveSpeed * Time.deltaTime;
        controller.Move(move);
     
    }
}
