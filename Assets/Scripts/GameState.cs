using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public int score = 0;
    int secondaryScore = 0;
    int balls = 3;
    public GameObject ball;
    bool running = true;
    public Text scoreText;

    void Start()
    {
        score = 0;
        balls = 3;
        scoreText.GetComponent<Text>().text = $"Score: {score}\nBalls: {balls}";
    }

    void OnTriggerEnter(Collider other) {
        if (balls == 0) {
            running = false;
        }
        if (other.gameObject.tag == "Ball" && running) {
            balls--;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = new Vector3(11, 1, -8);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (running) {
            secondaryScore += 1;
            if(secondaryScore > 600){
                secondaryScore = 0;
                score += 1;
            }
        }
        scoreText.text = $"Score = {score}\nBalls = {balls}";
    }
}
