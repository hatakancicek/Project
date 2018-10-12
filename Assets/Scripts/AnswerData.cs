using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using System.Collections;

[System.Serializable]
public class AnswerData : MonoBehaviour
{
    public string answer;
    public string correctAnswer;

    string _answer;
    Text _text;

    private void Awake()
    {
        _text = gameObject.GetComponent<Text>();
        UpdateAnswer(answer);
    }

    public string getAnswer()
    {
        return _text.text;
    }

    void UpdateAnswer(string answer)
    {

        _answer = answer;
        _text.text = answer;
        //isCorrect(answer);
    }

    bool isCorrect(string answer) {
        if (answer == correctAnswer)
            // puan ver
            return true;
        else
            // can eksilt
            return false;
    }

    // Use this for initialization
    void Start()
    {
        
    }


}
