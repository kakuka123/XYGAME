using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explore_001 : MonoBehaviour
{
    public GameObject exp1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="wall")
        {
            Instantiate(exp1,transform.position,transform.rotation);
            Destroy(gameObject);

            
        }
    }

}
