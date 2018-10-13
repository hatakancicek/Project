using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Level {
    public int order;
    public int tier;
    public int stars;
    public string subject;

    public Level(int _order, int _tier, int _stars, string _subject) {
        order = _order;
        tier = _tier;
        stars = _stars;
        subject = _subject;
    }
}

public class Levels {
    public Level[] levels;
}

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
    static Manager instance;
    public AchievementWrapper[] achievementWrappers;


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
        levels = new Levels
        {
            levels = new Level[2]
        };
        levels.levels[0] = new Level(0, 0, 3, "g");
        levels.levels[1] = new Level(1, 0, 3, "g");
        print(JsonUtility.ToJson(levels));

        SceneManager.LoadScene(1);
        Sound.instance.GetComponent<AudioSource>().mute |= sound != 1;

        OpenAchievement("n", "first");
    }

    void OpenAchievement(string _subject, string _id) {
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

        print(JsonUtility.ToJson(Manager.achievements));

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
}
