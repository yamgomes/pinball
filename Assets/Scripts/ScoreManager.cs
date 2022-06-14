using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class ScoreManager : MonoBehaviour
{
    [Serializable]
    public struct Player
    {
        public string name;
        public int score;

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public GameObject nameInput;

    public static ScoreManager instance;

    List<Player> players = new List<Player>();

    Text scoreboard;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreboard = GetComponent<Text>();
        if (!File.Exists("./scores.dat"))
        {
            Player p = new Player("Noob", 10);
            AddPlayer(p);
            p = new Player("Pro", 100);
            AddPlayer(p);
            p = new Player("Master", 1000);
            AddPlayer(p);
            p = new Player("Legend", 10000);
            AddPlayer(p);
            p = new Player("God", 100000);
            SaveScores();
            Debug.Log("Scores saved");
        }
        else
        {
            Debug.Log("Scores loaded");
            LoadScores();
        }
    }

    void SaveScores()
    {
        //save scores to file using BinaryFormatter
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("./scores.dat");
        bf.Serialize(file, players);
        file.Close();
    }

    void LoadScores()
    {
        //load scores from file using BinaryFormatter
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open("./scores.dat", FileMode.Open);
        players = (List<Player>)bf.Deserialize(file);
        file.Close();
        scoreboard.text = "";
        foreach (Player p in players)
        {
            scoreboard.text += p.name + " - " + p.score + "\n";
        }
    }

    public void EndScoreAdd()
    {
        Player p = new Player();
        p.name = nameInput.GetComponent<InputField>().text;
        p.score = GameManager.instance.score;
        AddPlayer(p);
        SaveScores();
    }

    void AddPlayer(Player player)
    {
        players.Add(player);
        players.Sort((x, y) => y.score.CompareTo(x.score));
    }
}
