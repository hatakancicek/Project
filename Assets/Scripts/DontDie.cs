using UnityEngine;
public class DontDie : MonoBehaviour
{
    public static DontDie instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}