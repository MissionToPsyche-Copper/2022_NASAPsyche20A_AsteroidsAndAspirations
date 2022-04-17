using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    public float letterSpeed;
    private float defaultSpeed = 0.02f;
    private float fastSpeed = 0.001f;

    private bool isTyping = false;
    delegate void EndingFunctions();
    List<EndingFunctions> PlayList;
    private int current = 0;

    private int jfMinPoints = 3;
    private int yssaMinPoints = 3;
    private int nixelMinPoints = 7;
    private int dogMinPoints = 1;

    private int jfPoints, yssaPoints, nixelPoints, dogPoints;
    private bool hasFuel, hasBatteries, hasToolbox;

    public GameObject[] buildings;
    public GameObject[] endingList;
    public Image background;

    void Start()
    {
        letterSpeed = defaultSpeed;

        if (ScoreUpdater.Instance != null)
        {
            jfPoints = ScoreUpdater.Instance.jfPoints;
            yssaPoints = ScoreUpdater.Instance.yssaPoints;
            nixelPoints = ScoreUpdater.Instance.nixelPoints;
            dogPoints = ScoreUpdater.Instance.dogPoints;
        }

        if ( QuestTracker.Instance != null )
        {
            hasFuel = QuestTracker.Instance.hasFuel;
            hasBatteries = QuestTracker.Instance.hasBatteries;
            hasToolbox = QuestTracker.Instance.hasToolbox;
        }

        PlayList = new List<EndingFunctions>();
        PlayList.Add(playJfEnd);
        PlayList.Add(playYssaEnd);
        PlayList.Add(playNixelEnd);
        PlayList.Add(playDogEnd);
        PlayList.Add(playCongrats);
        PlayList.Add(playRating);
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) && isTyping) letterSpeed = fastSpeed; 
        
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping && (current < PlayList.Count))
        {
            foreach (GameObject g in endingList)
            {
                g.SetActive(false);
            }
            letterSpeed = defaultSpeed;
            PlayList[current]();
            current++;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isTyping && (current >= PlayList.Count))
        {
            Debug.Log("Transition to end credits");
            // switch to end credits
            SceneTracker.Instance.LoadLevel("Credits Scene");
        }
    }

    private void playDogEnd()
    {
        if (dogPoints <= dogMinPoints) playEnding(endingList[6]);
        else playEnding(endingList[7]);
    }

    private void playNixelEnd()
    {
        if (nixelPoints <= nixelMinPoints) playEnding(endingList[4]);
        else playEnding(endingList[5]);
    }

    private void playYssaEnd()
    {
        if (yssaPoints <= yssaMinPoints) playEnding(endingList[2]);
        else playEnding(endingList[3]);
    }

    private void playJfEnd()
    {
        if (jfPoints <= jfMinPoints) playEnding(endingList[0]);
        else playEnding(endingList[1]);
    }

    private void playCongrats()
    {
        playEnding( endingList[16] );
    }

    private void playRating()
    {
        background.GetComponent<Animator>().SetTrigger("FadeOut");
        int numItems = 0;
        if ( hasFuel ) numItems++;
        if ( hasBatteries ) numItems++;
        if ( hasToolbox ) numItems++;

        if (numItems < 1) numItems = 1;

        if ( numItems == 3 )
        {
            playEnding( endingList[17] );
            buildings[0].SetActive(true);
            buildings[1].SetActive(true);
            buildings[2].SetActive(true);
        } 
        if ( numItems == 2 ) 
        {
            playEnding( endingList[18] );
            buildings[1].SetActive(true);
            buildings[2].SetActive(true);
        }
        if ( numItems == 1 ) 
        {
            playEnding( endingList[19] );
            buildings[2].SetActive(true);
        }
    }


    private void playEnding( GameObject end )
    {
        end.SetActive(true);
        Text[] endText = end.GetComponentsInChildren<Text>();
        foreach (Text t in endText)
            t.enabled = false;
        StartCoroutine( WaitForText( endText ) );

    }

    private IEnumerator WaitForText( Text[] text )
    {
        foreach (Text t in text)
        {
            t.enabled = true;
            yield return StartCoroutine( StartTyping( t ) ); 
        }
    }

    private IEnumerator StartTyping( Text text )
    {
        Debug.Log("started letterboxing");
        isTyping = true;
        string type = text.text;
        text.text = "";
        foreach( char c in type )
        {
            text.text += c;
            yield return new WaitForSeconds(letterSpeed);
            //yield return new WaitForSeconds(0.01f);
        }
        
        isTyping = false;
    }
}
