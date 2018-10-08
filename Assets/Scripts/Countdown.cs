﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public int time;

    int _time;
    Text _text;

    private void Awake()
    {
        _text = gameObject.GetComponent<Text>();
        UpdateTime(time);
    }

    void UpdateTime(int targetTime) {

        _time = targetTime;
        int minute = (int)Mathf.Floor(targetTime / 60);
        int second = (int)targetTime % 60;
        string minuteText = minute >= 10 ? minute.ToString() : "0" + minute.ToString();
        string secondText = second >= 10 ? second.ToString() : "0" + second.ToString();
        _text.text = minuteText + ":" + secondText;

        if (targetTime == 0) CancelInvoke();
    }

    // Use this for initialization
    void Start () {
        InvokeRepeating("SecondPassed", 0.0f, 1f);
    }
	
	// Update is called once per frame
    void SecondPassed() {
        print("Clock");
        UpdateTime(Mathf.Max(_time - 1, 0));
    }
}