using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Sprite locked;
    public AchievementWrapper ac;
    bool isUnlocked;

    void Start()
    {
        string[] achievements = Manager.achievements.achievements;

        isUnlocked = false;

        for (int i = 0; i < achievements.Length; i++)
        {
            if (achievements[i] == gameObject.name)
            {
                isUnlocked = true;
                break;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = isUnlocked ? ac.icon : locked;
    }
}
