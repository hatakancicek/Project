using UnityEngine;
using UnityEngine.UI;

public class Tier : MonoBehaviour {

    public Sprite locked;
    public Sprite unlocked;
    public int tier;
    public int numberOfLevels = 3;
    public GameObject tierLevels;
    public Font onDone;

    private void Start()
    {
        int previousTierStarCount = 0;

        if (tier == 0)
        {
            previousTierStarCount = 6;
        }
        else
        {
            Level[] levels = Manager.levels.levels;
            int levelsLength = levels.Length;
            int previousTier = tier - 1;

            for (int i = 0; i < levelsLength; i++)
            {
                Level _level = levels[i];
                if (_level.tier == previousTier && _level.subject == Manager.subject)
                {
                    previousTierStarCount = previousTierStarCount + _level.stars;
                }
            }
        }

        Text _text = transform.GetChild(0).GetComponent<Text>();

        if(tier == 0 || previousTierStarCount >= 6) {
            _text.text = "-->";
            _text.font = onDone;
        } else {
            _text.text = previousTierStarCount.ToString() + "/6";
        }

        GameObject _tierLevels = Instantiate(tierLevels, Vector2.zero, Quaternion.identity, transform);
        RectTransform rt = _tierLevels.GetComponent<RectTransform>();
        rt.localPosition = new Vector2(100, 0);
        TierLevels tl = _tierLevels.GetComponent<TierLevels>();
        tl.unlocked = unlocked;
        tl.locked = locked;
        tl.tier = tier;
        tl.previousTierStars = previousTierStarCount;
    }
}