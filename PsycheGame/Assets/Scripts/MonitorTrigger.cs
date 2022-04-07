using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorTrigger : MonoBehaviour
{
    public float radius = 7; // within this radius, the item can be interacted with
    public Transform player; // a reference to the player object
    public bool isTyping = false;

    [SerializeField]
    SceneTracker sceneTracker;
    [SerializeField]
    ScoreUpdater scoreUpdater;

    public Animator monitorController;
    public Animator alarmController;
    public bool alarmOn = true;
    public bool monitorOn = false;
    public bool monitorViewed = false;

    public DialogueManager dialogueManager;
    public GameObject bed;

    public Text monitorText;
    public Text monitorText2;


    string type;
    string type2;

    void Start()
    {
        sceneTracker = FindObjectOfType<SceneTracker>();
        scoreUpdater = FindObjectOfType<ScoreUpdater>();
        bed.GetComponent<ShowInteractPrompt>().promptText = ">> Not time for bed yet. <<";
        bed.GetComponent<LoadLevel>().enabled = false;
        type = monitorText.text;
        monitorText.text = "";
        type2 = monitorText2.text;
        monitorText2.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance ( player.position, this.transform.position ) < radius ) 
        {
            // the "z" key acts as the interact button
            if ( Input.GetKeyDown( "z" ) && !isTyping) 
            {

                if (scoreUpdater.talkedTo > 3)
                {
                    bed.GetComponent<ShowInteractPrompt>().promptText = ">> Go to Bed <<";
                    bed.GetComponent<LoadLevel>().enabled = true;
                    monitorText.text = "";
                    type = type2;
                    monitorViewed = false;
                    FindObjectOfType<AudioManager>().Stop("Alarm");
                    FindObjectOfType<AudioManager>().Stop("NightCityThriller");
                    FindObjectOfType<AudioManager>().Play("ChillAmbient");
                    alarmOn = false;
                }
                if (monitorOn)
                {
                    monitorOn = false;
                    monitorController.SetTrigger("MonitorOff");
                }
                else
                {
                    monitorOn = true;
                    monitorController.SetTrigger("MonitorOn");
                    FindObjectOfType<AudioManager>().Play("OpenMonitor");
                    if (!monitorViewed)
                    {
                        alarmController.SetTrigger("WarningOff");
                        monitorViewed = true;
                        StartCoroutine("StartTyping");
                    }
                }
            }
        }
    }

    IEnumerator StartTyping()
    {
        Debug.Log("started letterboxing");
        isTyping = true;
        foreach( char c in type )
        {
            monitorText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
    }
}
