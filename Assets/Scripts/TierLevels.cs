using UnityEngine;

public class TierLevels : MonoBehaviour
{

    public int tier;
    public int previousTierStars;
    public Sprite locked;
    public Sprite unlocked;
    public int numberOfLevels = 3;
    public GameObject level;

    private void Start()
    {
        for (int i = 0; i < numberOfLevels; i++)
        {
            GameObject _level = Instantiate(level, Vector2.zero, Quaternion.identity, transform);
            RectTransform rt = _level.GetComponent<RectTransform>();
            rt.localPosition = new Vector2(-150 + (i * 150), 0);
            _level.name = "Level " + i.ToString();
            LevelButton l = _level.GetComponent<LevelButton>();
            l.tier = tier;
            l.order = i;
            l.previousTierStarCount = previousTierStars;
            l.unlockedImage = unlocked;
            l.lockedImage = locked;
            l.Set();
        }
    }
}