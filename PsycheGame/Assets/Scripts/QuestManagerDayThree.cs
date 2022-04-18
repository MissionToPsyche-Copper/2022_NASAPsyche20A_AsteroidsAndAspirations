using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerDayThree : MonoBehaviour
{
    public Toggle fuel;
    public Toggle batteries;
    public Toggle toolbox;
    public Animator dayTag;

    public Transform player;
    public Transform respawnWireGame;
    public Transform respawnCardGame;
    public Transform respawnShipGame;

    //public DialogueTrigger npc;
    public DialogueSO day3Convo2;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerPosition();
        if (!QuestTracker.Instance.onDayThree)
        {
           QuestTracker.Instance.onDayThree = true;
            dayTag.SetTrigger("ShowDayTag");
        }
        if (QuestTracker.Instance.canEndDayThree) FindObjectOfType<DialogueTrigger>().dialogue = day3Convo2;
        CheckItems();
    }

    // Update is called once per frame
    void Update()
    {
        CheckItems();
    }

    private void CheckItems()
    {
        fuel.isOn = QuestTracker.Instance.hasFuel;
        batteries.isOn = QuestTracker.Instance.hasBatteries;
        toolbox.isOn = QuestTracker.Instance.hasToolbox;
    }

    public void enableEnd()
    {
        QuestTracker.Instance.canEndDayThree = true;
    }

    private void LoadPlayerPosition()
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        if (QuestTracker.Instance.playedWireGame)
        {
            player.position = respawnWireGame.position;
            player.rotation = respawnWireGame.rotation;
            QuestTracker.Instance.playedWireGame = false;
        }
        if (QuestTracker.Instance.playedCardGame)
        {
            player.position = respawnCardGame.position;
            player.rotation = respawnCardGame.rotation;
            QuestTracker.Instance.playedCardGame = false;
        }
        if (QuestTracker.Instance.playedShipGame)
        {
            player.position = respawnShipGame.position;
            player.rotation = respawnShipGame.rotation;
            QuestTracker.Instance.playedShipGame = false;
        }
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
