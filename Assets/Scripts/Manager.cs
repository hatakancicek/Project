using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    public Sprite backgroundImageF;
    public Sprite achievementIconF;

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

        Invoke("ShowFirstGameNotification", 2);
    }

    void ShowFirstGameNotification() {
        ShowAchievement(backgroundImageF, achievementIconF, "İlk Oyunu Tamamladın!");
    }

    void ShowAchievement(Sprite background, Sprite achievement, string description) {
        descriptionText.text = description;
        backgroundImage.sprite = background;
        achievementIcon.sprite = achievement;
        anim.SetTrigger("Show");
    }
}
