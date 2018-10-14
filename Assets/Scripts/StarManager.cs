using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{

    Image[] stars;
    public int lives;
    int total;
    public static StarManager instance;

    readonly Color32 lostStar = new Color32(133, 90, 90, 255);
    readonly Color32 wonStar = new Color32(255, 255, 255, 255);

    public void SetLives(int newLives)
    {
        lives = newLives;
        UpdateStars();
    }

    public void UpdateStars()
    {
        for (int i = 0; i < total; i++)
        {
            stars[i].color = lostStar;
        }
        for (int i = 0; i < lives; i++)
        {
            stars[i].color = wonStar;
        }
    }

    public void LooseAStar()
    {
        if (lives != 0) lives--;
        UpdateStars();
    }

    private void Awake()
    {
        instance = this;
        stars = transform.GetComponentsInChildren<Image>();
        lives = stars.Length;
        total = lives;
        UpdateStars();
    }
}