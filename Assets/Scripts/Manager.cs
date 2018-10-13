using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class Level {
    public int order;
    public int tier;
    public int stars;
    public string subject;
    public bool time;

    public Level(int _order, int _tier, int _stars, string _subject, bool _time) {
        order = _order;
        tier = _tier;
        stars = _stars;
        subject = _subject;
        time = _time;
    }
}

[System.Serializable]
public class Levels {
    public Level[] levels;
}

[System.Serializable]
public class Achievements {
    public string[] achievements;
}

public class Manager : MonoBehaviour {
    public static int sound;
    public static Achievements achievements;
    public static Levels levels;
    public static string subject;
    public Text descriptionText;
    public Image backgroundImage;
    public Image achievementIcon;
    public Animator anim;
    public static Manager instance;
    public AchievementWrapper[] achievementWrappers;

    public Sprite n_time;
    public Sprite a_time;
    public Sprite g_time;

    public static Level currentLevel;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        sound = PlayerPrefs.GetInt("sound", 0);

        string _achievements = PlayerPrefs.GetString("achievements", "{\"achievements\":[]}");
        achievements = JsonUtility.FromJson<Achievements> (_achievements);
        if (achievements.achievements == null) achievements.achievements = new string[0];

        string _levels = PlayerPrefs.GetString("levels", "{\"levels\":[]}");
        levels = JsonUtility.FromJson<Levels>(_levels);

        if (levels.levels == null) levels.levels = new Level[0];

        SceneManager.LoadScene(1);
        Sound.instance.GetComponent<AudioSource>().mute |= sound != 1;

        FinishLevel(0, 0, 3, "g", false);
    }

    public void OpenAchievement(string _subject, string _id) {
        string[] _achievements = Manager.achievements.achievements;
        string target = _subject + "_" + _id;
        for (int i = 0; i < _achievements.Length; i++) {
            string _achievement = _achievements[i];
            if (_achievement == target)
                return;
        }

        Array.Resize(ref _achievements, _achievements.Length + 1);
        _achievements[_achievements.GetUpperBound(0)] = target;

        Manager.achievements.achievements = _achievements;
        PlayerPrefs.SetString("achievements", JsonUtility.ToJson(Manager.achievements));
        
        for (int i = 0; i < achievementWrappers.Length; i++) {
            AchievementWrapper _a = achievementWrappers[i];
            if(_a.subject == _subject && _a.id == _id) {
                descriptionText.text = _a.description;
                backgroundImage.sprite = _a.background;
                achievementIcon.sprite = _a.icon;
                anim.SetTrigger("Show");
            }
        }
    }

    public void FinishLevel(int _order, int _tier, int _stars, string _subject, bool _time) {
        Level[] _levels = levels.levels;
        for (int i = 0; i < _levels.Length; i++) {
            Level _l = _levels[i];
            if(_l.order == _order && _l.subject == _subject && _l.tier == _tier) {
                bool newTime = _time || _l.time;
                int newStar = Math.Max(_stars, _l.stars);
                Level newLevel = new Level(_order, _tier, newStar, _subject, newTime);
                _levels[i] = newLevel;
                Manager.levels.levels = _levels;
                PlayerPrefs.SetString("levels", JsonUtility.ToJson(Manager.levels));
                return;
            }
        }

        Array.Resize(ref _levels, _levels.Length + 1);
        _levels[_levels.GetUpperBound(0)] = new Level(_order, _tier, _stars, _subject, _time);

        Manager.levels.levels = _levels;
        PlayerPrefs.SetString("levels", JsonUtility.ToJson(Manager.levels));
        print(JsonUtility.ToJson(Manager.levels));

    }
}