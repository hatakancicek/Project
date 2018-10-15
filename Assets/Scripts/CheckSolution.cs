using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class CheckSolution : MonoBehaviour
{
    public GameObject Answer;
    public GameObject First1;
    public GameObject Second2;
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;
    public StarManager instance;
    public ScoreChange score;
    public ScoreChange questionNumber;
    public int SceneNumber;

    private void Start()
    {
        Check();
        Answer.GetComponent<Text>().enabled = false;

    }
    public void Check()
    {
        int option1;
        int option2;
        int answer;
        bool answerInSolution = false;
        int randomizer = (Manager.currentLevel.tier + 1) * 20;
        int j;
        int randomNumber1 = 0;
        int randomNumber2 = 0;
        int randomOption1 = 0;
        int randomOption2 = 0;
        int randomOption3 = 0;
        int randomOption4 = 0;
        int[] liste = { randomNumber1, randomNumber2, randomOption1, randomOption2, randomOption3, randomOption4 };
        int option = UnityEngine.Random.Range(0, 4);
        liste[0] = UnityEngine.Random.Range(0, randomizer);
        do
        {
            liste[1] = UnityEngine.Random.Range(0, randomizer);
        } while (liste[0] == liste[1]||(liste[0] + liste[1])<4);
        
            First1.GetComponent<Text>().text = liste[0].ToString();
        Second2.GetComponent<Text>().text = liste[1].ToString();
        int.TryParse(First1.GetComponent<Text>().text, out option1);
        int.TryParse(Second2.GetComponent<Text>().text, out option2);
        answer = option1 + option2;
        int optionRandomizer = answer / 2;
        for (int i = 2; i < 6; i++)
        {
            liste[i] = UnityEngine.Random.Range(optionRandomizer, 3 * optionRandomizer);
        }
        for (int i = 2; i < 6; i++)
        {
            for (j = 2; j < i; j++)
            {
                while (liste[i] == liste[j])
                {
                    print(liste[2]);
                    print(liste[3]);
                    print(liste[4]);
                    print(liste[5]);
                    liste[i] = UnityEngine.Random.Range(optionRandomizer, 3*optionRandomizer);
                    j = 2;
                    print(liste[2]);
                    print(liste[3]);
                    print(liste[4]);
                    print(liste[5]);
                }
            }

        }
        
        Number1.GetComponent<Text>().text = liste[2].ToString();
        Number2.GetComponent<Text>().text = liste[3].ToString();
        Number3.GetComponent<Text>().text = liste[4].ToString();
        Number4.GetComponent<Text>().text = liste[5].ToString();
        
        Answer.GetComponent<Text>().text = answer.ToString();
        for (int k = 2; k < 6; k++)
        {
            if (liste[k] == answer) answerInSolution = true;
        }
        if (!answerInSolution)
        {
            if (option == 0) Number1.GetComponent<Text>().text = Answer.GetComponent<Text>().text;
            else if (option == 1) Number2.GetComponent<Text>().text = Answer.GetComponent<Text>().text;
            else if (option == 2) Number3.GetComponent<Text>().text = Answer.GetComponent<Text>().text;
            else if (option == 3) Number4.GetComponent<Text>().text = Answer.GetComponent<Text>().text;
        }

    }
    public void CheckIfTrue()
    {
        int option1;
        int option2;
        int answer;
        string trueAnswer = Answer.GetComponent<Text>().text;
        if (trueAnswer != GetComponent<Text>().text) instance.LooseAStar();
        else score.increaseScore();
        questionNumber.increaseScore();
        int.TryParse(First1.GetComponent<Text>().text, out option1);
        int.TryParse(Second2.GetComponent<Text>().text, out option2);
        answer = option1 + option2;
        Answer.GetComponent<Text>().text = answer.ToString();
        Check();
    }
}
