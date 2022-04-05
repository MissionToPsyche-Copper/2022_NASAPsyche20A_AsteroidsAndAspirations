using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    static public Main Instance;
    public int wireCount;
    public Animator winScreen;
    private int matchedCount = 0;

    public void Awake()
    {
        Instance = this;
    }
    public void match(int points)
    {
        matchedCount += points;

        if(matchedCount == wireCount)
        {
            QuestTracker.Instance.hasToolbox = true;
            winScreen.SetTrigger("ShowWinScreen");
        }
    }

    public void quitButton()
    {
        if (QuestTracker.Instance.onDayThree) SceneTracker.Instance.LoadLevel("DayThree");
        else SceneTracker.Instance.LoadLevel("DayTwo");
    }
}
