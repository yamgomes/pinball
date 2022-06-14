using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    public int score = 0;
    int balls = 3;
    public GameObject ball;
    GameState state = GameState.Start;
    public Text scoreText;
    float timer;
    List<GameObject> menuItems = new List<GameObject>();
    List<GameObject> gameplayItems = new List<GameObject>();
    List<GameObject> gameOverItems = new List<GameObject>();

    public void AddPoints(int points)
    {
        score += points;
    }

    void Start()
    {
        score = 0;
        balls = 3;
        scoreText.text = "";
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("MainMenu"))
        {
            menuItems.Add(item);
        }
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Gameplay"))
        {
            gameplayItems.Add(item);
        }
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("GameOver"))
        {
            gameOverItems.Add(item);
        }
    }

    public void BeginGame()
    {
        foreach (GameObject obj in menuItems)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in gameplayItems)
        {
            obj.SetActive(true);
        }
        state = GameState.Playing;
        timer = 0;
    }

    public void OnBallDeath()
    {
        if (balls == 0)
        {
            state = GameState.GameOver;
        }
        if (state == GameState.Playing)
        {
            balls--;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = new Vector3(11, 0.55f, -8);
        }
    }

    void Update()
    {
        if (state == GameState.Start) { }
        else if (state == GameState.Playing)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                timer = 0;
                score += 1;
            }
            scoreText.text = $"Score = {score}\nBalls = {balls}";
        }
        else if (state == GameState.GameOver) { }
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Start
}
