using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CevapBulma : MonoBehaviour
{

    public int choiceValue;

    int _choiceValue;
    Text _text;

    private void Awake()
    {
        _text = gameObject.GetComponent<Text>();
        UpdateValue(choiceValue);
    }

    void UpdateValue(int targetValue)
    {

        _choiceValue = targetValue;
        string valueText = targetValue.ToString();
        print(valueText);
        _text.text = valueText;
    }

    // Use this for initialization

    // Update is called once per frame
    void SecondPassed()
    {
        print("Clock");
    }
}
