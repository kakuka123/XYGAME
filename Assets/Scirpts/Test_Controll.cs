using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Diagnostics.Tracing;

public class Test_Controll : MonoBehaviour
{
    public float speed=5;
    public float rotationspeed=10;
    private EventListener<bool> listenerTest;
    // Start is called before the first frame update
    void Start()
    {
        listenerTest = new EventListener<bool>();
        listenerTest.OnVariableChange += Test;
    }
    private void OnDestroy()
    {
        listenerTest.OnVariableChange -= Test;
    }



    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
 
        var anim = GetComponent<Animator>();
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        transform.Translate(dir*speed*Time.deltaTime,Space.World);

        if (dir!=Vector3.zero)
        {
            Quaternion toRatation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRatation, rotationspeed * Time.deltaTime);
        }


        bool Actor_IsRun_h = Mathf.Abs(dir.x) > 0;
        bool Actor_IsRun_v = Mathf.Abs(dir.z) > 0;
        //if (transform.Translate==)
        //{
        //    anim.SetBool("IsRun", true);
        //}
        //else
        //{
        //    anim.SetBool("IsRun", false);
        //}
        //这里写监听事件
        listenerTest.Value = Input.GetKey(KeyCode.W);

    }
    private void Test(bool value)
    {
        Debug.Log(value);
    }

}

public class EventListener<T>
{

    public delegate void OnValueChangeDelegate(T newVal);
    public event OnValueChangeDelegate OnVariableChange;

    private T m_value;
    public T Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if (m_value.Equals(value)) return;
            OnVariableChange?.Invoke(value);
            m_value = value;
        }
    }
}