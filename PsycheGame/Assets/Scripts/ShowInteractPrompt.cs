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

    void Update()
    {
        if ( !openPrompt && Vector3.Distance ( player.position, this.transform.position ) < radius ) 
        {
            // player is now within radius; when player leaves radius set back to false
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

    public void ShowPrompt() => animator.SetTrigger("ShowPrompt");
    public void ClosePrompt() => animator.SetTrigger("ClosePrompt");

}
