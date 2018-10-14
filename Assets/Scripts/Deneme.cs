using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Deneme : MonoBehaviour {

    public GameObject Number1;
    public GameObject Number2;
    
    public void Awake()
    {
        
        int choiceint1;
        int choiceint2;
        Text answer = GetComponent<Text>();
        Text choice1 = Number1.GetComponent<Text>();
        Text choice2 = Number2.GetComponent<Text>();
        print(choice1.text);
        print(choice2.text);
        int.TryParse(choice1.text, out choiceint1);
        int.TryParse(choice2.text, out choiceint2);
        print(choice1.text);
        print(choice2.text);
        print(choiceint1);
        print(choiceint2);
        int answer1 = choiceint1 + choiceint2;
        answer.text = answer1.ToString();

    }
    public void Start()
    {
        GetComponent<Text>().enabled = false;
    }
}
