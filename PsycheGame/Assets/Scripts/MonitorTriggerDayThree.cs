using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorTriggerDayThree : MonoBehaviour
{

    public float letterSpeed;
    private float defaultSpeed = 0.02f;
    private float fastSpeed = 0.001f;

    public float radius = 7; // within this radius, the item can be interacted with
    public Transform player; // a reference to the player object

    public Animator monitorController;
    public bool monitorOn = false;
    public bool isTyping = false;

    //public DialogueManager dialogueManager;

    public Text monitorText;
    public Text monitorText2;

    string type;

    void Start()
    {
        letterSpeed = defaultSpeed;
        if ( QuestTracker.Instance.canEndDayThree )
        {
            type = monitorText2.text;
            monitorText.text = "";
        }
        else
        {
            type = monitorText.text;
            monitorText.text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance ( player.position, this.transform.position ) < radius ) 
        {
            if ( Input.GetKeyDown( KeyCode.Space ) && isTyping) letterSpeed = fastSpeed;
            // the "z" key acts as the interact button
            if ( Input.GetKeyDown( KeyCode.Space ) && !isTyping) 
            {
                if (monitorOn)
                {
                    player.gameObject.GetComponent<PlayerMovement>().enabled = false;
                    monitorOn = false;
                    monitorController.SetTrigger("MonitorOff");
                    monitorText.text = "";
                    letterSpeed = defaultSpeed;
                    if (QuestTracker.Instance.canEndDayThree) SceneTracker.Instance.LoadLevel("EndScene");
                }
                else
                {
                    player.gameObject.GetComponent<PlayerMovement>().enabled = false;
                    FindObjectOfType<AudioManager>().Play("OpenMonitor");
                    
                    if ( QuestTracker.Instance.canEndDayThree )
                    {
                        letterSpeed = 0.4f;
                        type = monitorText2.text;
                        monitorText.text = "";
                    }
                    
                    monitorOn = true;
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
            yield return new WaitForSeconds(letterSpeed);
        }
        isTyping = false;
    }
}
