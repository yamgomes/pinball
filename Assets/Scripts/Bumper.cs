using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force = 1000f;
    public GameState deadZone;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision other) {
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        deadZone.score += 1000;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
