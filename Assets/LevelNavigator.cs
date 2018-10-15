using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNavigator : MonoBehaviour
{
    public LevelButton lb1;
    public int LevelNumber;

    void NavigatePlaySceene()
    {
       SceneManager.LoadScene(LevelNumber+lb1.order+lb1.tier);
    }

    private void Start()
    {

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(NavigatePlaySceene);
    }
}

