using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject firepoint;//�����
    public GameObject explore;//��ըЧ��
    public Rigidbody pp1;//�����ӵ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody clone1;
            Debug.Log("Fire");
            clone1=Instantiate(pp1, transform.position, transform.rotation) as Rigidbody;
            clone1.velocity = transform.TransformDirection(Vector3.right * 30);





        }
    }
}
