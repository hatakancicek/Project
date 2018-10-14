using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigate : MonoBehaviour {
    public int SceneNumber;
    public string subject;

    void NavigatePlaySceene()
    {

        if (subject != "") Manager.subject = subject;

       
        SceneManager.LoadScene(SceneNumber);
    }

    private void Start()
    {

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(NavigatePlaySceene);
    }
}
