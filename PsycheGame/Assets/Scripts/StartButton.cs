using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void startGame()
    {
        SceneTracker.Instance.LoadLevel("DayOne");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
