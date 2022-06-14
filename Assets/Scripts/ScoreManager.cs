using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    List<Player> players = new List<Player>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadScores();
    }

    void SaveScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scores/score.dat");
        bf.Serialize(file, players);
        file.Close();
    }

    void LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/scores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(
                Application.persistentDataPath + "/scores.dat",
                FileMode.Open
            );
            List<Player> data = (List<Player>)bf.Deserialize(file);
            players = new List<Player>(data);
            file.Close();
        }
        else
            Debug.LogError("No scores!");
    }

    void NewScore()
    {
        Player player = new Player();
        player.name = "Player";
        player.score = 0;
        players.Add(player);
    }
}

class Player
{
    public string name;
    public int score;
}
