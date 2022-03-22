using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorTrigger : MonoBehaviour
{
    public float radius = 7; // within this radius, the item can be interacted with
    public Transform player; // a reference to the player object

    public Animator monitorController;
    public Animator alarmController;
    public bool monitorOn = false;
    public bool monitorViewed = false;
    //public bool shipDecision = false;

    public DialogueManager dialogueManager;

    public Text monitorText;
    public Text monitorText2;

    public ScoreUpdater scoreUpdater;

    string type;
    string type2;

    void Start()
    {
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
            if ( Input.GetKeyDown( "z" )) 
            {
                if (scoreUpdater.talkedTo > 3)
                {
                    monitorText.text = "";
                    type = type2;
                    monitorViewed = false;
                }
                if (monitorOn)
                {
                    monitorOn = false;
                    monitorController.SetTrigger("MonitorOff");
                    //if ( type == type2 ) 
                    //{
                        //GetComponent<DialogueTrigger>().StartDialogue();
                        //shipDecision = true;
                    //}
                }
                else
                {
                    monitorOn = true;
                    monitorController.SetTrigger("MonitorOn");
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
        foreach( char c in type )
        {
            monitorText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
