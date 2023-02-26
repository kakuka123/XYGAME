using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_Destory : MonoBehaviour
{
    private ParticleSystem[] particleSystems;
    // Start is called before the first frame update
    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        bool allStoped = true;
        foreach (ParticleSystem ps in particleSystems)
        {
            if (!ps.isStopped)
            {
                allStoped = false;
            }
        }
        if (allStoped)
        {
            GameObject.Destroy(gameObject);
        }

    }
}
