using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject
{
    [SerializeField] FloatVariable score;
    [SerializeField] FloatVariable highScore;
    [SerializeField] StringEvent onIncreaseScore;
    [SerializeField] StringEvent displayHighScore;

    public void Init()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        score.SetValue(0);
    }

    public void IncreaseScore(float amount)
    {
        score.ApplyChange((int) amount);
        onIncreaseScore.Raise(score.Value.ToString());
    }

    public void DisplayHighscore()
    {
        displayHighScore.Raise("HighScore : " + highScore.Value);
    }

   /* public void Save()
    {
        highScore.SetValue(score.Value);
        PlayerPrefs.SetFloat("HighScore", highScore.Value);
        *//*BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/score.txt");
        List<System.Object> objects = new List<System.Object>();
        objects.Add(highScore);
        *//*var json = JsonUtility.ToJson(highScore);*//*
        bf.Serialize(file, objects);
        file.Close();*//*
    }

    public void LoadData()
    {
        highScore.SetValue(PlayerPrefs.GetFloat("HighScore"));
        *//*BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/score.txt");
        var json = JsonUtility.ToJson(highScore);
        bf.Serialize(file, highScore.Value);
        file.Close();*//*
    }*/
}
