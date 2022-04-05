using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGameManager : MonoBehaviour
{
    public void backButton()
    {
        SceneTracker.Instance.LoadLevel("Menu Guide a spacecraft");
    }

    public void quitButton()
    {
        if (QuestTracker.Instance.onDayThree) SceneTracker.Instance.LoadLevel("DayThree");
        else SceneTracker.Instance.LoadLevel("DayTwo");
    }
}
