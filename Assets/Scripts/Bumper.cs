using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        GameManager.instance.AddPoints(100);
    }
}
