using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yepper : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.AddPoints(1000);
        other.gameObject.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * other.gameObject.GetComponent<Rigidbody>().velocity.magnitude* 2;
    }
}
