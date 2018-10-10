using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Initiliaze : MonoBehaviour {

    public int SceneNumber;


    // Use this for initialization
    void Start () {
        SceneManager.LoadScene(SceneNumber);
    }
}
