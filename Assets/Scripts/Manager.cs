using UnityEngine;
using UnityEngine.SceneManagement;

public class Level {
    public int order;
    public int tier;
    public int stars;

    public Level(int _order, int _tier, int _stars) {
        order = _order;
        tier = _tier;
        stars = _stars;
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
    }
}
