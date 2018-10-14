using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GNavigate : MonoBehaviour
{
    public LevelButton lb;

    public void SetLevel()
    {
        Manager.currentLevel = new Level(lb.order, lb.tier, 0, Manager.subject, false);
    }
}
