using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractPrompt : MonoBehaviour
{
    public Animator animator;
    public Text promptUI;
    public string promptText;
    public Transform player;
    public float radius = 7f;
    public bool openPrompt = false;
    public bool dialogueAvailable = false;

    void Update()
    {
        if ( gameObject.GetComponent<Interactable>() != null )
        {
            bool convoStarted = gameObject.GetComponent<Interactable>().convoStarted;
            if (convoStarted) promptUI.enabled = false;
            else promptUI.enabled = true;
            
            dialogueAvailable = gameObject.GetComponent<DialogueTrigger>().dialogue.isAvailable;

            // Is an NPC
            if (dialogueAvailable)
            {
                if ( !openPrompt && Vector3.Distance ( player.position, this.transform.position ) < radius ) 
                {
                    // player is now within radius; when player leaves radius set back to false
                    //promptUI.enabled = true;
                    promptUI.text = promptText;
                    ShowPrompt();
                    openPrompt = true;
                }
                
                if ( openPrompt && !(Vector3.Distance ( player.position, this.transform.position ) < radius) )
                {
                    ClosePrompt();
                    openPrompt = false;
                }
            }
            else
            {
                if ( openPrompt )
                {
                    ImmediateClose();
                    openPrompt = false;
                }
            }
            
        }
        else
        {
            // Not an NPC
            if ( !openPrompt && Vector3.Distance ( player.position, this.transform.position ) < radius ) 
            {
                // player is now within radius; when player leaves radius set back to false
                promptUI.enabled = true;
                promptUI.text = promptText;
                ShowPrompt();
                openPrompt = true;
            }
            
            if ( openPrompt && !(Vector3.Distance ( player.position, this.transform.position ) < radius) )
            {
                ClosePrompt();
                openPrompt = false;
            }
        }
    }

    public void ShowPrompt() => animator.SetTrigger("ShowPrompt");
    public void ClosePrompt() => animator.SetTrigger("ClosePrompt");
    public void ImmediateClose() => animator.SetTrigger("ImmediateClose");

}
