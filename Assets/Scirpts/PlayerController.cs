using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float movespeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor=Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor!=0||ver!=0)
        {
            Movement(hor,ver);
        }
    }


    private void Movement(float hor,float ver)
    {
        hor *= movespeed * Time.deltaTime;
        ver *= movespeed * Time.deltaTime;

        this.transform.Translate(hor, 0, ver);

    }
}
