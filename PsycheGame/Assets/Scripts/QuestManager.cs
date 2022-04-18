using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    public Animator loadingscreen;
    public Animator questListNotif;
    public Animator dayTag;
    public GameObject bed;

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
    public DialogueSO yssaConvo3;

    [Header("Incident Tracker")]
    public GameObject wireRepairStation;
    public GameObject cardsStation;
    public GameObject shipStation;
    public GameObject pointer1; // talk to yssa
    public GameObject smoke;

    [Header("Player Position Tracker")]
    public Transform player;
    public Transform playerRespawn;
    public Transform playerRespawn2;
    public Transform respawnWireGame;
    public Transform respawnCardGame;
    public Transform respawnShipGame;
    public ShowRoomTag[] roomTags;

    [Header("NPC Position Tracker")]
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

    [Header("Task Tracker")]
    public GameObject taskPanel1;
    public GameObject taskPanel2;
    public GameObject taskPanel3;

    public Toggle toggletask1;
    public Toggle toggletask2;
    public Toggle toggletask3;
    public Toggle toggletask4;
    public Toggle toggletask5;
    public Toggle toggletask6;
    public Toggle toggletask7;
    public Toggle toggletask8;
    public Toggle toggletask9;

    public Toggle fuel;
    public Toggle batteries;
    public Toggle toolbox;

    void Start()
    {
        if (!QuestTracker.Instance.onDayTwo)
        {
            QuestTracker.Instance.onDayTwo = true;
            dayTag.SetTrigger("ShowDayTag");
        }
        Debug.Log("LOADING DAY TWO");

        loadingscreen = FindObjectOfType<SceneTracker>().transition;

        loadCurrentConversations();
        loadAvailableConversations();

        LoadPlayerPosition();

        if (QuestTracker.Instance.positions1) MovePositionOne();
        if (QuestTracker.Instance.positions2) MovePositionsTwo();
        if (QuestTracker.Instance.positions3) MovePositionsThree();

        loadTasks();
    }

    void Update()
    {

        CheckTasks();
        CheckItems();

        saveCurrentConversations();
        loadAvailableConversations();

        CheckIncident();
    }

    private void LoadPlayerPosition()
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        if (QuestTracker.Instance.playedWireGame)
        {
            roomTags[0].inThisRoom = false;
            roomTags[1].inThisRoom = false;
            roomTags[2].inThisRoom = false;
            roomTags[3].inThisRoom = false;
            roomTags[4].inThisRoom = true;

            Debug.Log("In front of wire station.");
            player.position = respawnWireGame.position;
            player.rotation = respawnWireGame.rotation;
            QuestTracker.Instance.playedWireGame = false;
        }
        if (QuestTracker.Instance.playedCardGame)
        {
            roomTags[0].inThisRoom = false;
            roomTags[1].inThisRoom = false;
            roomTags[2].inThisRoom = true;
            roomTags[3].inThisRoom = false;
            roomTags[4].inThisRoom = false;

            player.position = respawnCardGame.position;
            player.rotation = respawnCardGame.rotation;
            QuestTracker.Instance.playedCardGame = false;
        }
        if (QuestTracker.Instance.playedShipGame)
        {
            roomTags[0].inThisRoom = true;
            roomTags[1].inThisRoom = false;
            roomTags[2].inThisRoom = false;
            roomTags[3].inThisRoom = false;
            roomTags[4].inThisRoom = false;

            player.position = respawnShipGame.position;
            player.rotation = respawnShipGame.rotation;
            QuestTracker.Instance.playedShipGame = false;
        }
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }

    private void loadTasks()
    {
        if (QuestTracker.Instance.alarmWasTriggered)
        {
            taskPanel1.SetActive(false);
            taskPanel2.SetActive(true);
            taskPanel3.SetActive(false);
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

        if (QuestTracker.Instance.tasksDone) UpdateTaskPanelThree();
        else
        {
            bed.GetComponent<ShowInteractPrompt>().promptText = ">> Not time for bed yet. <<";
            bed.GetComponent<LoadLevel>().enabled = false;
        }
    }

    private void UpdateTaskPanelThree()
    {
        taskPanel1.SetActive(false);
        taskPanel2.SetActive(false);
        taskPanel3.SetActive(true);
        bed.GetComponent<ShowInteractPrompt>().promptText = ">> Go to Bed. <<";
        bed.GetComponent<LoadLevel>().enabled = true;
    }

    private void loadAvailableConversations()
    {
        jConvo3.isAvailable = QuestTracker.Instance.jConvo3isAvailable;

        ixelConvo2.isAvailable = QuestTracker.Instance.ixelConvo2isAvailable;
        ixelConvo3.isAvailable = QuestTracker.Instance.ixelConvo3isAvailable;

        nmosaConvo2.isAvailable = QuestTracker.Instance.nmosaConvo2isAvailable;

        yssaConvo1.isAvailable = QuestTracker.Instance.yssaConvo1isAvailable;
        yssaConvo2.isAvailable = QuestTracker.Instance.yssaConvo2isAvailable;
        yssaConvo3.isAvailable = QuestTracker.Instance.yssaConvo3isAvailable;
    }

    private void loadCurrentConversations()
    {
        jCurrentConvo.currentConvo = QuestTracker.Instance.jCurrentConvo;
        iCurrentConvo.currentConvo = QuestTracker.Instance.iCurrentConvo;
        nCurrentConvo.currentConvo = QuestTracker.Instance.nCurrentConvo;
        yCurrentConvo.currentConvo = QuestTracker.Instance.yCurrentConvo;

        Interactable jfObj = jf.gameObject.GetComponentInChildren<Interactable>();
        if (jCurrentConvo.currentConvo >= jfObj.conversationList.conversations.Length)
        {
            jf.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
            jfObj.conversationList.conversations[jfObj.conversationList.conversations.Length - 1];
        }
        else
        {
            jf.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
                jfObj.conversationList.conversations[jCurrentConvo.currentConvo];
        }

        Interactable yssaObj = yssa.gameObject.GetComponentInChildren<Interactable>();
        if (yCurrentConvo.currentConvo >= yssaObj.conversationList.conversations.Length)
        {
            yssa.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
            yssaObj.conversationList.conversations[yssaObj.conversationList.conversations.Length - 1];
        }
        else
        {
            yssa.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
                yssaObj.conversationList.conversations[yCurrentConvo.currentConvo];
        }

        Interactable nmosaObj = nmosa.GetComponentInChildren<Interactable>();
        if (nCurrentConvo.currentConvo >= nmosaObj.conversationList.conversations.Length)
        {
            nmosa.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
                nmosaObj.conversationList.conversations[nmosaObj.conversationList.conversations.Length - 1];
        }
        else
        {
            nmosa.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
                nmosaObj.conversationList.conversations[nCurrentConvo.currentConvo];
        }

        Interactable ixelObj = ixel.gameObject.GetComponentInChildren<Interactable>();
        if (iCurrentConvo.currentConvo >= ixelObj.conversationList.conversations.Length)
        {
            ixel.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
                ixelObj.conversationList.conversations[ixelObj.conversationList.conversations.Length - 1];
        }
        else
        {
            ixel.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue =
                ixelObj.conversationList.conversations[iCurrentConvo.currentConvo];
        }
    }

    private void CheckIncident()
    {
        if (QuestTracker.Instance.task1Complete && QuestTracker.Instance.task2Complete
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

    private void saveCurrentConversations()
    {
        if (jCurrentConvo.currentConvo > 0) QuestTracker.Instance.jCurrentConvo = jCurrentConvo.currentConvo;
        if (iCurrentConvo.currentConvo > 0) QuestTracker.Instance.iCurrentConvo = iCurrentConvo.currentConvo;
        if (nCurrentConvo.currentConvo > 0) QuestTracker.Instance.nCurrentConvo = nCurrentConvo.currentConvo;
        if (yCurrentConvo.currentConvo > 0) QuestTracker.Instance.yCurrentConvo = yCurrentConvo.currentConvo;
    }

    public void CheckAlarm()
    {

        if ( QuestTracker.Instance.task1Complete && QuestTracker.Instance.task2Complete 
            && QuestTracker.Instance.task3Complete && QuestTracker.Instance.task4Complete && !QuestTracker.Instance.alarmWasTriggered )
        {
            Debug.Log("move positions part 1");
            if (!QuestTracker.Instance.positions1)
            {
                movePositions(1);
                QuestTracker.Instance.positions1 = true;
                QuestTracker.Instance.positions2 = false;
                QuestTracker.Instance.positions3 = false;
            }
        }
        else if ( QuestTracker.Instance.alarmWasTriggered )
        {
            alarm.SetTrigger("WarningOff");
            FindObjectOfType<AudioManager>().Stop("Alarm");

            if ( iCurrentConvo.currentConvo == 2 && !QuestTracker.Instance.yssaConvo2isAvailable )
            {
                // move yssa to the medroom
                QuestTracker.Instance.yssaConvo2isAvailable = true;
                Debug.Log("move positions part 2");
                if(!QuestTracker.Instance.positions2)
                {
                    movePositions( 2 );
                    QuestTracker.Instance.positions1 = false;
                    QuestTracker.Instance.positions2 = true;
                    QuestTracker.Instance.positions3 = false;
                }
            }

            if ( yCurrentConvo.currentConvo == 3 )
            {
                // update task panel
                if ( QuestTracker.Instance.alarmWasTriggered )
                {
                    taskPanel1.SetActive(false);
                    taskPanel2.SetActive(true);
                }
                // enable the rest of Day 2 conversations
                // update everyone's positions
                Debug.Log("move positions part 3");
                if( !QuestTracker.Instance.positions3 )
                {
                    FindObjectOfType<AudioManager>().Stop("NightCityThriller");
                    FindObjectOfType<AudioManager>().Play("ChillAmbient");
                    movePositions( 3 );
                    
                    QuestTracker.Instance.positions1 = false;
                    QuestTracker.Instance.positions2 = false;
                    QuestTracker.Instance.positions3 = true;
                }
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
            if ( !QuestTracker.Instance.task5Complete && yCurrentConvo.currentConvo > 3 )
            {
                QuestTracker.Instance.task5Complete = true;
                toggletask5.isOn = true;
            }

            if ( !QuestTracker.Instance.task6Complete && jCurrentConvo.currentConvo > 2 )
            {
                QuestTracker.Instance.task6Complete = true;
                toggletask6.isOn = true;
            }

            if ( !QuestTracker.Instance.task7Complete && yCurrentConvo.currentConvo > 5 )
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

        if (!QuestTracker.Instance.tasksDone) CheckTasksDone();

    }

    private void CheckTasksDone()
    {
        if (
            QuestTracker.Instance.task1Complete &&
            QuestTracker.Instance.task2Complete &&
            QuestTracker.Instance.task3Complete &&
            QuestTracker.Instance.task4Complete &&
            QuestTracker.Instance.task5Complete &&
            QuestTracker.Instance.task6Complete &&
            QuestTracker.Instance.task7Complete &&
            QuestTracker.Instance.task8Complete &&
            QuestTracker.Instance.task9Complete
        )
        {
            QuestTracker.Instance.tasksDone = true;
            UpdateTaskPanelThree();
        } 
    }

    private void movePositions( int placementNumber )
    {

        StartCoroutine(PlayTransition(placementNumber));

    }

    IEnumerator PlayTransition( int placementNumber )
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        switch (placementNumber)
        {
            case 1:
                loadingscreen.SetTrigger("ShortTimeSkip");
                yield return new WaitForSeconds(3f);

                pointer1.SetActive(true);
                smoke.SetActive(true);
                wireRepairStation.SetActive(false);
                cardsStation.SetActive(false);
                shipStation.SetActive(false);

                if (!QuestTracker.Instance.alarmWasTriggered)
                {
                    FindObjectOfType<AudioManager>().Stop("ChillAmbient");
                    FindObjectOfType<AudioManager>().Play("NightCityThriller");
                    FindObjectOfType<AudioManager>().Play("Alarm");
                    alarm.SetTrigger("WarningOn");
                    QuestTracker.Instance.alarmWasTriggered = true;
                }
                
                Interactable yssaObj = yssa.gameObject.GetComponentInChildren<Interactable>();
                yssa.gameObject.GetComponentInChildren<DialogueTrigger>().dialogue = yssaObj.conversationList.conversations[1];
                yCurrentConvo.currentConvo = 1;
                //move the player in front of the engine room
                roomTags[0].inThisRoom = false;
                roomTags[1].inThisRoom = false;
                roomTags[2].inThisRoom = false;
                roomTags[3].inThisRoom = false;
                roomTags[4].inThisRoom = false;

                player.position = playerRespawn.position;
                player.rotation = playerRespawn.rotation;

                MovePositionOne();
                
                break;
            case 2:
                smoke.SetActive(false);
                MovePositionsTwo();
                break;
            case 3:
                loadingscreen.SetTrigger("ShortTimeSkip");
                yield return new WaitForSeconds(1f);
                roomTags[0].inThisRoom = true;
                roomTags[1].inThisRoom = false;
                roomTags[2].inThisRoom = false;
                roomTags[3].inThisRoom = false;
                roomTags[4].inThisRoom = false;
                player.position = playerRespawn2.position;
                player.rotation = playerRespawn2.rotation;
                MovePositionsThree();
                yield return new WaitForSeconds(3f);
                
                QuestTracker.Instance.nmosaConvo2isAvailable = true;
                QuestTracker.Instance.ixelConvo3isAvailable = true;
                QuestTracker.Instance.jConvo3isAvailable = true;
                QuestTracker.Instance.yssaConvo3isAvailable = true;

                wireRepairStation.SetActive(true);
                cardsStation.SetActive(true);
                shipStation.SetActive(true);
                questListNotif.SetTrigger("ShowQuestListNotif");
                break;
        }
        player.gameObject.GetComponent<CharacterController>().enabled = true;

    }

    private void MovePositionsThree()
    {
        yssa.position = yssaPosition4.position;
        yssa.rotation = yssaPosition4.rotation;

        jf.position = jfPosition3.position;
        jf.rotation = jfPosition3.rotation;

        nmosa.position = nmosaPosition3.position;
        nmosa.rotation = nmosaPosition3.rotation;

        ixel.position = ixelPosition3.position;
        ixel.rotation = ixelPosition3.rotation;
    }

    private void MovePositionsTwo()
    {
        yssa.position = yssaPosition3.position;
        yssa.rotation = yssaPosition3.rotation;
    }

    private void MovePositionOne()
    {
        // moving yssa to door of the engine room and everyone else to the medroom
        yssa.position = yssaPosition2.position;
        yssa.rotation = yssaPosition2.rotation;

        jf.position = jfPosition2.position;
        jf.rotation = jfPosition2.rotation;

        nmosa.position = nmosaPosition2.position;
        nmosa.rotation = nmosaPosition2.rotation;

        ixel.position = ixelPosition2.position;
        ixel.rotation = ixelPosition2.rotation;
    }
}
