using UnityEngine;
using UnityEngine.UI;

public class SoundIcon : MonoBehaviour
{
    public Sprite noSound;
    public Sprite sound;
    Image _image;
    AudioSource player;
    bool _sound;
    private void Awake()
    {
        _sound = Manager.sound == 1 ? true : false;
        _image = gameObject.GetComponent<Image>();
        _image.sprite = _sound ? sound : noSound;
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToggleSound);

        player = Sound.instance.GetComponent<AudioSource>();
    }

    void ToggleSound()
    {
        _sound = !_sound;
        _image.sprite = _sound ? sound : noSound;
        player.mute = !_sound;
        PlayerPrefs.SetInt("sound", _sound ? 1 : 0);
    }
}
