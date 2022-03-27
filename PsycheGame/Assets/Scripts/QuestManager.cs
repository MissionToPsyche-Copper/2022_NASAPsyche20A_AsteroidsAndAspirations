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

    //public bool alarmWasTriggered = false;

    [Header("Task Tracker")]
    public GameObject taskPanel1;
    public GameObject taskPanel2;

    /*
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
    */

    public Toggle toggletask1;
    public Toggle toggletask2;
    public Toggle toggletask3;
    public Toggle toggletask4;
    public Toggle toggletask5;
    public Toggle toggletask6;
    public Toggle toggletask7;
    public Toggle toggletask8;
    public Toggle toggletask9;

    // more bools for items here
    /*
    public bool hasFuel = false;
    public bool hasBatteries = false;
    public bool hasToolbox = false;
    */

    // more toggles for items here
    public Toggle fuel;
    public Toggle batteries;
    public Toggle toolbox;

    void Start()
    {
        loadingscreen = FindObjectOfType<SceneTracker>().transition;

        jCurrentConvo.currentConvo = QuestTracker.Instance.jCurrentConvo;
        iCurrentConvo.currentConvo = QuestTracker.Instance.iCurrentConvo;
        nCurrentConvo.currentConvo = QuestTracker.Instance.nCurrentConvo;
        yCurrentConvo.currentConvo = QuestTracker.Instance.yCurrentConvo;

        jConvo3.isAvailable = QuestTracker.Instance.jConvo3isAvailable;

        ixelConvo2.isAvailable = QuestTracker.Instance.ixelConvo2isAvailable;
        ixelConvo3.isAvailable = QuestTracker.Instance.ixelConvo3isAvailable;

        nmosaConvo2.isAvailable = QuestTracker.Instance.nmosaConvo2isAvailable;

        yssaConvo1.isAvailable = QuestTracker.Instance.yssaConvo1isAvailable;
        yssaConvo2.isAvailable = QuestTracker.Instance.yssaConvo2isAvailable;

        if (QuestTracker.Instance.positions1) movePositions(1);
        if (QuestTracker.Instance.positions2) movePositions(2);
        if (QuestTracker.Instance.positions3) movePositions(3);
        if ( QuestTracker.Instance.alarmWasTriggered ) 
        {
            taskPanel1.SetActive(false);
            taskPanel2.SetActive(true);
        }

        toggletask1.isOn = QuestTracker.Instance.task1Complete;
        toggletask2.isOn = QuestTracker.Instance.task2Complete;
        toggletask3.isOn = QuestTracker.Instance.task3Complete;
        toggletask4.isOn = QuestTracker.Instance.task4Complete;
        toggletask5.isOn = QuestTracker.Instance.task5Complete;
        toggletask6.isOn = QuestTracker.Instance.task6Complete;
        toggletask7.isOn = QuestTracker.Instance.task7Complete;
        toggletask8.isOn = QuestTracker.Instance.task8Complete;
        toggletask9.isOn = QuestTracker.Instance.task9Complete;

    }

    void Update()
    {

        CheckTasks();
        CheckItems();

        jConvo3.isAvailable = QuestTracker.Instance.jConvo3isAvailable;

        ixelConvo2.isAvailable = QuestTracker.Instance.ixelConvo2isAvailable;
        ixelConvo3.isAvailable = QuestTracker.Instance.ixelConvo3isAvailable;

        nmosaConvo2.isAvailable = QuestTracker.Instance.nmosaConvo2isAvailable;

        yssaConvo1.isAvailable = QuestTracker.Instance.yssaConvo1isAvailable;
        yssaConvo2.isAvailable = QuestTracker.Instance.yssaConvo2isAvailable;

        if ( QuestTracker.Instance.task1Complete && QuestTracker.Instance.task2Complete 
            && QuestTracker.Instance.task3Complete && QuestTracker.Instance.task4Complete && !QuestTracker.Instance.incident)
        {
            QuestTracker.Instance.incident = true;
            Debug.Log("First four tasks complete! Alarm should trigger after this conversation");
            // enabling convo1 for yssa
            QuestTracker.Instance.yssaConvo1isAvailable = true;
            // enabling convo2 for ixel
            QuestTracker.Instance.ixelConvo2isAvailable = true;
        }
    }

    public void CheckAlarm()
    {

        if ( QuestTracker.Instance.task1Complete && QuestTracker.Instance.task2Complete 
            && QuestTracker.Instance.task3Complete && QuestTracker.Instance.task4Complete && !QuestTracker.Instance.alarmWasTriggered )
        {
            QuestTracker.Instance.positions1 = true;
            QuestTracker.Instance.positions2 = false;
            QuestTracker.Instance.positions3 = false;
            movePositions(1);
        }
        else if ( QuestTracker.Instance.alarmWasTriggered )
        {
            alarm.SetTrigger("WarningOff");

            if ( iCurrentConvo.currentConvo == 2 && !QuestTracker.Instance.yssaConvo2isAvailable )
            {
                // move yssa to the medroom
                QuestTracker.Instance.yssaConvo2isAvailable = true;
                QuestTracker.Instance.positions1 = false;
                QuestTracker.Instance.positions2 = true;
                QuestTracker.Instance.positions3 = false;
                movePositions( 2 );
            }

            if ( yCurrentConvo.currentConvo == 2 )
            {
                // update task panel
                taskPanel1.SetActive(false);
                taskPanel2.SetActive(true);
                // enable the rest of Day 2 conversations
                QuestTracker.Instance.nmosaConvo2isAvailable = true;
                QuestTracker.Instance.ixelConvo3isAvailable = true;
                QuestTracker.Instance.jConvo3isAvailable = true;
                QuestTracker.Instance.positions1 = false;
                QuestTracker.Instance.positions2 = false;
                QuestTracker.Instance.positions3 = true;
                // update everyone's positions
                movePositions( 3 );
            }

        }
    }

    public void CheckItems()
    {
        fuel.isOn = QuestTracker.Instance.hasFuel;
        batteries.isOn = QuestTracker.Instance.hasBatteries;
        toolbox.isOn = QuestTracker.Instance.hasToolbox;
    }
    public void CheckTasks()
    {
        if ( taskPanel1.activeSelf )
        {
            if ( !QuestTracker.Instance.task1Complete && jCurrentConvo.currentConvo > 0 )
            {
                QuestTracker.Instance.task1Complete = true;
                toggletask1.isOn = true;
            }

            if ( !QuestTracker.Instance.task2Complete && iCurrentConvo.currentConvo > 0 )
            {
                QuestTracker.Instance.task2Complete = true;
                toggletask2.isOn = true;
            }

            if ( !QuestTracker.Instance.task3Complete && nCurrentConvo.currentConvo > 0 )
            {
                QuestTracker.Instance.task3Complete = true;
                toggletask3.isOn = true;
            }

            if ( !QuestTracker.Instance.task4Complete && jCurrentConvo.currentConvo > 1 )
            {
                QuestTracker.Instance.task4Complete = true;
                toggletask4.isOn = true;
            }
        }
        else
        {
            if ( !QuestTracker.Instance.task5Complete && yCurrentConvo.currentConvo > 2 )
            {
                QuestTracker.Instance.task5Complete = true;
                toggletask5.isOn = true;
            }

            if ( !QuestTracker.Instance.task6Complete && jCurrentConvo.currentConvo > 2 )
            {
                QuestTracker.Instance.task6Complete = true;
                toggletask6.isOn = true;
            }

            if ( !QuestTracker.Instance.task7Complete && yCurrentConvo.currentConvo > 4 )
            {
                QuestTracker.Instance.task7Complete = true;
                toggletask7.isOn = true;
            }

            if ( !QuestTracker.Instance.task8Complete && nCurrentConvo.currentConvo > 1 )
            {
                QuestTracker.Instance.task8Complete = true;
                toggletask8.isOn = true;
            }

            if ( !QuestTracker.Instance.task9Complete && iCurrentConvo.currentConvo > 2 )
            {
                QuestTracker.Instance.task9Complete = true;
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

                if (!QuestTracker.Instance.alarmWasTriggered)
                {
                    alarm.SetTrigger("WarningOn");
                    QuestTracker.Instance.alarmWasTriggered = true;
                }
                
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
