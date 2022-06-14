using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noper : MonoBehaviour
{
    public GameState deadZone;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) {
        deadZone.score -= 500;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
