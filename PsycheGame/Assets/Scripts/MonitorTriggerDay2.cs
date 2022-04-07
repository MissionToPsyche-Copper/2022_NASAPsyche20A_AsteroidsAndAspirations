using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorTriggerDay2 : MonoBehaviour
{
    public float radius = 7; // within this radius, the item can be interacted with
    public Transform player; // a reference to the player object

    public Animator monitorController;
    public bool monitorOn = false;
    public bool isTyping = false;

    public DialogueManager dialogueManager;

    public Text monitorText;

    string type;

    void Start()
    {
        type = monitorText.text;
        monitorText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance ( player.position, this.transform.position ) < radius ) 
        {
            // the "z" key acts as the interact button
            if ( Input.GetKeyDown( "z" ) && !isTyping) 
            {
                if (monitorOn)
                {
                    monitorOn = false;
                    monitorController.SetTrigger("MonitorOff");
                    monitorText.text = "";
                }
                else
                {
                    monitorOn = true;
                    FindObjectOfType<AudioManager>().Play("OpenMonitor");
                    monitorController.SetTrigger("MonitorOn");
                    StartCoroutine(StartTyping());
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
