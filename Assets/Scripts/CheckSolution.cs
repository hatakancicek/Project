using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class CheckSolution : MonoBehaviour {
    public GameObject Answer;
    public StarManager instance;
    public ScoreChange score;
    public ScoreChange questionNumber;
    public bool isFirstFalse=true;
    public int SceneNumber;
    //static public CheckSolution GameObject;
	// Use this for initialization
	public void Check () {
        string trueAnswer = Answer.GetComponent<Text>().text;
        Answer.GetComponent<Text>().enabled = true;
        if (trueAnswer != GetComponent<Text>().text&&isFirstFalse)
        {
            print("false");
            instance.LooseAStar();
            isFirstFalse = false;
            Answer.GetComponent<Text>().enabled = true;
        }
        else if(trueAnswer != GetComponent<Text>().text)
        {
            print("false111");
        }
        else
        {
            print("true");
            score.increaseScore();
            print(score.score);
        }
        questionNumber.increaseScore();
        print(questionNumber.score);
        //randomize options
    }
	
}
