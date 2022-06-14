using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yepper : MonoBehaviour
{
    public GameState deadZone;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) {
        deadZone.score += 500000;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
