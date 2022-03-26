using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Animator loadingscreen;
    [Header("NPC Conversation Tracker")]
    public Interactable jCurrentConvo;
    public DialogueSO jConvo3;

    public Interactable iCurrentConvo;
    public DialogueSO ixelConvo2;
    public DialogueSO ixelConvo3;

    public Interactable nCurrentConvo;
    public DialogueSO nmosaConvo2;

    public Interactable yCurrentConvo;
    public DialogueSO yssaConvo1;
    public DialogueSO yssaConvo2;

    [Header("NPC Position Tracker")]
    public Transform player;
    public Transform playerRespawn;
    public Transform playerRespawn2;

    public Transform yssa;
    public Transform yssaPosition2;
    public Transform yssaPosition3;
    public Transform yssaPosition4;

    public Transform jf;
    public Transform jfPosition2;
    public Transform jfPosition3;

    public Transform nmosa;
    public Transform nmosaPosition2;
    public Transform nmosaPosition3;

    public Transform ixel;
    public Transform ixelPosition2;
    public Transform ixelPosition3;

    [Header("Alarm Tracker")]
    public Animator alarm;
    public bool alarmWasTriggered = false;

    [Header("Task Tracker")]
    public GameObject taskPanel1;
    public GameObject taskPanel2;

    public bool incident = false;
    public bool task1Complete = false;
    public bool task2Complete = false;
    public bool task3Complete = false;
    public bool task4Complete = false;
    public bool task5Complete = false;
    public bool task6Complete = false;
    public bool task7Complete = false;
    public bool task8Complete = false;
    public bool task9Complete = false;

    // more bools for items here

    public Toggle toggletask1;
    public Toggle toggletask2;
    public Toggle toggletask3;
    public Toggle toggletask4;
    public Toggle toggletask5;
    public Toggle toggletask6;
    public Toggle toggletask7;
    public Toggle toggletask8;
    public Toggle toggletask9;

    // more toggles for items here

    void Start()
    {
        jConvo3.isAvailable = false;

        ixelConvo2.isAvailable = false;
        ixelConvo3.isAvailable = false;

        nmosaConvo2.isAvailable = false;

        yssaConvo1.isAvailable = false;
        yssaConvo2.isAvailable = false;
    }

    void Update()
    {
        CheckTasks();

        if ( task1Complete && task2Complete && task3Complete && task4Complete && !incident)
        {
            incident = true;
            Debug.Log("First four tasks complete! Alarm should trigger after this conversation");
            // enabling convo1 for yssa
            yssaConvo1.isAvailable = true;
            // enabling convo2 for ixel
            ixelConvo2.isAvailable = true;
        }
    }

    public void CheckAlarm()
    {
        if ( task1Complete && task2Complete && task3Complete && task4Complete && !alarmWasTriggered )
        {
            movePositions(1);
        }
        else if ( alarmWasTriggered )
        {
            alarm.SetTrigger("WarningOff");

            if ( iCurrentConvo.currentConvo == 2 && !yssaConvo2.isAvailable )
            {
                // move yssa to the medroom
                yssaConvo2.isAvailable = true;
                movePositions( 2 );
            }

            if ( yCurrentConvo.currentConvo == 2 )
            {
                // update task panel
                taskPanel1.SetActive(false);
                taskPanel2.SetActive(true);
                // enable the rest of Day 2 conversations
                nmosaConvo2.isAvailable = true;
                ixelConvo3.isAvailable = true;
                jConvo3.isAvailable = true;
                // update everyone's positions
                movePositions( 3 );
            }

        }
    }

    public void CheckTasks()
    {
        if ( taskPanel1.activeSelf )
        {
            if ( !task1Complete && jCurrentConvo.currentConvo > 0 )
            {
                task1Complete = true;
                toggletask1.isOn = true;
            }

            if ( !task2Complete && iCurrentConvo.currentConvo > 0 )
            {
                task2Complete = true;
                toggletask2.isOn = true;
            }

            if ( !task3Complete && nCurrentConvo.currentConvo > 0 )
            {
                task3Complete = true;
                toggletask3.isOn = true;
            }

            if ( !task4Complete && jCurrentConvo.currentConvo > 1 )
            {
                task4Complete = true;
                toggletask4.isOn = true;
            }
        }
        else
        {
            if ( !task5Complete && yCurrentConvo.currentConvo > 2 )
            {
                task5Complete = true;
                toggletask5.isOn = true;
            }

            if ( !task6Complete && jCurrentConvo.currentConvo > 2 )
            {
                task6Complete = true;
                toggletask6.isOn = true;
            }

            if ( !task7Complete && yCurrentConvo.currentConvo > 4 )
            {
                task7Complete = true;
                toggletask7.isOn = true;
            }

            if ( !task8Complete && nCurrentConvo.currentConvo > 1 )
            {
                task8Complete = true;
                toggletask8.isOn = true;
            }

            if ( !task9Complete && iCurrentConvo.currentConvo > 2 )
            {
                task9Complete = true;
                toggletask9.isOn = true;
            }
        }

    }

    private void movePositions( int placementNumber )
    {

        StartCoroutine(PlayTransition(placementNumber));

    }

    IEnumerator PlayTransition( int placementNumber )
    {
        switch (placementNumber)
        {
            case 1:
                loadingscreen.SetTrigger("ShortTimeSkip");
                yield return new WaitForSeconds(3f);

                alarm.SetTrigger("WarningOn");
                alarmWasTriggered = true;
                
                //move the player in front of the engine room
                player.position = playerRespawn.position;
                player.rotation = playerRespawn.rotation;

                // moving yssa to door of the engine room and everyone else to the medroom
                yssa.position = yssaPosition2.position;
                yssa.rotation = yssaPosition2.rotation;

                jf.position = jfPosition2.position;
                jf.rotation = jfPosition2.rotation;

                nmosa.position = nmosaPosition2.position;
                nmosa.rotation = nmosaPosition2.rotation;

                ixel.position = ixelPosition2.position;
                ixel.rotation = ixelPosition2.rotation;
                break;
            case 2:
                yssa.position = yssaPosition3.position;
                yssa.rotation = yssaPosition3.rotation;
                break;
            case 3:
                loadingscreen.SetTrigger("ShortTimeSkip");
                yield return new WaitForSeconds(3f);
                //move the player back to the control room
                player.position = playerRespawn2.position;
                player.rotation = playerRespawn2.rotation;

                yssa.position = yssaPosition4.position;
                yssa.rotation = yssaPosition4.rotation;

                jf.position = jfPosition3.position;
                jf.rotation = jfPosition3.rotation;

                nmosa.position = nmosaPosition3.position;
                nmosa.rotation = nmosaPosition3.rotation;

                ixel.position = ixelPosition3.position;
                ixel.rotation = ixelPosition3.rotation;
                break;
        }

    }

    // method for updating items here
}
