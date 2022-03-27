using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public static ScoreUpdater Instance;

    public int talkedTo = 0;
    public int goodEnd = 0;
    public int badEnd = 0;

    //public Text petText;
    //public Text goodText;
    //public Text badText;

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

    public void AddtoConversationsHad()
    {
        talkedTo++;
        //petText.text = "pets: " + pets;
    }

    public void AddGoodEnd()
    {
        goodEnd++;
        //goodText.text = "points to good end: " + goodEnd;
    }

       public void AddBadEnd()
    {
        badEnd++;
        //badText.text = "points to bad end: " + badEnd;
    }


}
