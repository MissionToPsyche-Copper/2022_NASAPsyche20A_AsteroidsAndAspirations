using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    static public Main Instance;
    public int wireCount;
    public GameObject winText;
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
            winText.SetActive(true);
        }
    }
}
