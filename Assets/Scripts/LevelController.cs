using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public static LevelController instance;
    Level current;

    private void Awake()
    {
        instance = this;
        current = Manager.currentLevel;
    }

    public void FinishLevel() {
        bool time = Countdown.instance.timePerfect;
        int stars = StarManager.instance.lives;

        Manager.instance.FinishLevel(current.order, 
                                     current.tier, 
                                     stars, 
                                     current.subject, 
                                     time);

        if (current.order == 0 && current.tier == 0) Manager.instance.OpenAchievement(current.subject, "first");
        if (current.order == 2 && current.tier == 0) Manager.instance.OpenAchievement(current.subject, "tier");
        if (current.order == 2 && current.tier == 2) Manager.instance.OpenAchievement(current.subject, "done");
        if(Manager.levels.levels.Length == 9) {
            if (stars == 3)
            {
                int totalStars = 0;
                for (int i = 0; i < Manager.levels.levels.Length; i++)
                {
                    Level _level = Manager.levels.levels[i];
                    totalStars += _level.stars;
                }

                if (totalStars == 27) Manager.instance.OpenAchievement(current.subject, "star");
            }
            if (time)
            {
                for (int i = 0; i < Manager.levels.levels.Length; i++)
                {
                    Level _level = Manager.levels.levels[i];
                    if (!_level.time) return;
                }

                Manager.instance.OpenAchievement(current.subject, "time");
            }
        }
    }
}
