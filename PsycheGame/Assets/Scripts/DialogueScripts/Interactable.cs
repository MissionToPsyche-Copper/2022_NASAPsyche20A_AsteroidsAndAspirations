using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    // when this script is attached to an object, it will check if the player
    // is within a certain radius
    // if the player is within that radius and presses the interact button,
    // a dialogue will be trigged.

    public DialogueManager dialogueManager;

    public float radius = 7; // within this radius, the item can be interacted with
    public Transform player; // a reference to the player object
    public Transform npc;
    public int currentConvo = 0; // a number which identifies which conversation to load when interacted with
    public bool convoStarted = false;
    public bool convoEnded = false;

    // for score updater
    public GameEvent TalkedToNPC;
    public bool talkedTo = false;

    public ConversationList conversationList;

    void Update()
    {
        checkPlayerDistance();
    }

    private void checkPlayerDistance()
    {
        if ( Vector3.Distance ( player.position, this.transform.position ) < radius ) 
        {
            // the "z" key acts as the interact button
            if ( Input.GetKeyDown( "z" ) ) 
            {
                if ( !convoStarted ) 
                {
                    Vector3 facingPlayer = new Vector3( player.position.x, 
                                        npc.position.y, 
                                        player.position.z );
                    npc.LookAt( facingPlayer );
                    GetComponent<DialogueTrigger>().StartDialogue();
                    currentConvo++;
                    if (!talkedTo)
                    {
                        talkedTo = true;
                        TalkedToNPC.Raise();
                    }
                }
                else if ( dialogueManager.currentSentence.HasOptions() ) { return; }
                else if ( !convoEnded ) dialogueManager.GoToNextSentence();
            }
        }
    }

    public void setConvoStarted()
    {
        convoStarted = true;
        convoEnded = false;
    }

    public void setConvoEnded()
    {
        convoEnded = true;
        convoStarted = false;
        //currentConvo++;
        // move on to the next convo
        if ( currentConvo < conversationList.conversations.Length )
        {
            GetComponent<DialogueTrigger>().dialogue = conversationList.conversations[currentConvo];
        }
    }
}
