using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float restingPosition = 0f;
    public float maxPosition = 45f;
    public float force = 100f;
    public float paddleDamper = 15f;
    public string inputName;
    HingeJoint hinge;

    void Start() {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update() {

        JointSpring spring = new JointSpring();
        spring.spring = force;
        spring.damper = paddleDamper;

        if (Input.GetAxis(inputName) == 1) {
            spring.targetPosition = maxPosition;
        } else {
            spring.targetPosition = restingPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
