using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Achievement : MonoBehaviour {

    public string achievementName;
    public Sprite locked;
    public Sprite unlocked;
    bool isUnlocked;

    // Use this for initialization
    void Start () {
        string[] achievements = Manager.achievements.achievements;

        isUnlocked = false;

        for (int i = 0; i < achievements.Length; i++) {
            if(achievements[i] == achievementName) {
                isUnlocked = true;
                break;
            }
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = isUnlocked ? unlocked : locked;
	}

    void OnMouseDown()
    {
        ToggleAchievement();
    }

    void ToggleAchievement() {
        print("Click");
        isUnlocked = !isUnlocked;
        gameObject.GetComponent<SpriteRenderer>().sprite = isUnlocked ? unlocked : locked;
        string[] achievements = Manager.achievements.achievements;

        if (isUnlocked) {
            Array.Resize(ref achievements, achievements.Length + 1);
            achievements[achievements.GetUpperBound(0)] = achievementName;
        } else {
            for (int i = 0; i < achievements.Length; i++)
            {
                if (achievements[i] == achievementName)
                {
                    achievements[i] = null;
                }
            }
        }

        Manager.achievements.achievements = achievements;

        PlayerPrefs.SetString("achievements", JsonUtility.ToJson(Manager.achievements));
        print(JsonUtility.ToJson(Manager.achievements));

    }

    // Update is called once per frame
    void Update () {
		
	}
}
