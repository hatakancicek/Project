using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour {

    Image[] stars;
    int lives;
    int total;

    readonly Color32 lostStar = new Color32(133, 90, 90, 255);
    readonly Color32 wonStar = new Color32(255, 255, 255, 255);

    public void SetLives(int newLives) {
        lives = newLives;
        UpdateStars();
    }

    void UpdateStars() {
        for (int i = 0; i < total; i++)
        {
            stars[i].color = lostStar;
        }
        for (int i = 0; i < lives; i++)
        {
            stars[i].color = wonStar;
        }
    }

    private void Awake()
    {
        stars = transform.GetComponentsInChildren<Image>();
        lives = stars.Length;
        total = lives;
        UpdateStars();
    }
}