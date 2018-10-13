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
        Level level = new Level(order, tier, 0);
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
                    if (_level.order == previousLevelOrder)
                    {
                        locked = false;
                    } else if(_level.order == order && _level.tier == tier) {
                        level = _level;
                    }
                }
            }
        }

        if (locked) {
            image.sprite = lockedImage;
            stars.SetLives(0);
        } else {
            image.sprite = unlockedImage;
            text.text = (order + 1).ToString();
            stars.SetLives(level.stars);
        }
    }
}