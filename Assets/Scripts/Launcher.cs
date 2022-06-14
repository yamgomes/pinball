using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    SpringJoint spring;
    public float springForce = 1000f;
    public float speed = 10f;
    Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
        spring = GetComponent<SpringJoint>();
    }

    void Update()
    {
        if (Input.GetKey("s"))
        {
            spring.spring = 0;
            transform.position = transform.position + new Vector3(0, 0, -speed*0.001f);
        }else{
            spring.spring = springForce;
        }
        transform.position = transform.position.z < -18 ? new Vector3(transform.position.x, transform.position.y, -18) : transform.position;
    }
}
