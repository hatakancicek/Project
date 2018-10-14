using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ScoreChange : MonoBehaviour
{
    public int SceneNumber;
    public int score;
    public LevelController checker;
    public void increaseScore()
    {

        int.TryParse(GetComponent<Text>().text, out score);
        score++;
        GetComponent<Text>().text = score.ToString();
        if (GetComponent<Text>().text == "10")
        {
            checker.FinishLevel();
            SceneManager.LoadScene(SceneNumber);

        }
    }
}
