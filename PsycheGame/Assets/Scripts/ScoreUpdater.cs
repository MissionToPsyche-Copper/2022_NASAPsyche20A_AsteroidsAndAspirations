using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public static ScoreUpdater Instance;

    public int talkedTo = 0;

    //***** J9F4 FRIENDSHIP POINTS
    public int jfPoints = 0;

    //***** N'IXEL FRIENDSHIP POINTS
    public int nixelPoints = 0;

    //***** YSSA FRIENDSHIP POINTS
    public int yssaPoints = 0;

    //***** DOG FRIENDSHIP POINTS
    public int dogPoints = 0;

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

    public void AddToJf( int points ) => jfPoints += points;
    public void AddToNixel( int points ) => nixelPoints += points;
    public void AddToYssa( int points ) => yssaPoints += points;
    public void AddToDog( int points ) => dogPoints += points;
    


}
