using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour
{
    public static QuestTracker Instance;

    public int jCurrentConvo = 0;
    public bool jConvo3isAvailable = false;

    public int iCurrentConvo = 0;
    public bool ixelConvo2isAvailable = false;
    public bool ixelConvo3isAvailable = false;

    public int nCurrentConvo = 0;
    public bool nmosaConvo2isAvailable = false;

    public int yCurrentConvo = 0;
    public bool yssaConvo1isAvailable = false;
    public bool yssaConvo2isAvailable = false;

    public bool positions1 = false;
    public bool positions2 = false;
    public bool positions3 = false;

    public bool alarmWasTriggered = false;

    public bool incident = false;
    public bool task1Complete = false;
    public bool task2Complete = false;
    public bool task3Complete = false;
    public bool task4Complete = false;
    public bool task5Complete = false;
    public bool task6Complete = false;
    public bool task7Complete = false;
    public bool task8Complete = false;
    public bool task9Complete = false;

    // more bools for items here
    public bool hasFuel = false;
    public bool hasBatteries = false;
    public bool hasToolbox = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
