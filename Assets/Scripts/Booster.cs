using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody bola = other.gameObject.GetComponent<Rigidbody>();
        bola.AddForce(bola.velocity, ForceMode.Impulse);
        GameManager.instance.AddPoints(500);
    }
}
