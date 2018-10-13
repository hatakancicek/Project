using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    public int order;
    public int tier;
    public Sprite lockedImage;
    public Sprite unlockedImage;
    public int previousTierStarCount;

    public void Set()
    {
        Image image = gameObject.GetComponent<Image>();
        Text text = transform.GetChild(0).GetComponent<Text>();
        StarManager stars = transform.GetChild(1).GetComponent<StarManager>();
        Level level = new Level(order, tier, 0, Manager.subject, false);
        bool locked = true;
        Level[] levels = Manager.levels.levels;
        int levelsLength = levels.Length;
        int previousLevelOrder = order - 1;

        if(previousTierStarCount >= 6) {
            if(order == 0) {
                locked = false;
            } else {
                for (int i = 0; i < levelsLength; i++)
                {
                    Level _level = levels[i];
                    if (_level.order == previousLevelOrder
                        && _level.tier == tier
                        && _level.subject == Manager.subject)
                    {
                        locked = false;
                    }
                }
            }
        }


        for (int i = 0; i < levelsLength; i++)
        {
            Level _level = levels[i];

            if (_level.order == order
              && _level.tier == tier
              && _level.subject == Manager.subject)
            {
                level = _level;
            }
        }

        if (locked) {
            image.sprite = lockedImage;
            stars.SetLives(0);
        } else if(level.time) {
            switch(level.subject) {
                case "a":
                    image.sprite = Manager.instance.a_time;
                    break;
                case "g":
                    image.sprite = Manager.instance.g_time;
                    break;
                case "n":
                    image.sprite = Manager.instance.n_time;
                    break;
            }

            stars.SetLives(level.stars);
        } else {
            image.sprite = unlockedImage;
            text.text = (order + 1).ToString();
            stars.SetLives(level.stars);
        }
    }
}