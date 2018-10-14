using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;

    private void Awake()
    {
        instance = this;
    }
}