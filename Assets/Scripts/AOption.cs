using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AOption : MonoBehaviour
{

    public bool isTrue;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(FinishLevel);
    }

    public void FinishLevel()
    {
        LevelController.instance.FinishLevel();
        if (isTrue)
            trueAnswer();
        else
            falseAnswer();
    }

    public void trueAnswer()
    {
        SceneManager.LoadScene(4);
    }

    public void falseAnswer()
    {

    }
}
