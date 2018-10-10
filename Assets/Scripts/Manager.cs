using UnityEngine;
using UnityEngine.SceneManagement;

public class Level {
    public string name;
    public int stars;
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
        print(achievements.achievements[0]);

        string _levels = PlayerPrefs.GetString("levels", "{\"levels\":[]}");
        levels = JsonUtility.FromJson<Levels>(_levels);
        SceneManager.LoadScene(1);
        Sound.instance.GetComponent<AudioSource>().mute |= sound != 1;
    }
}
