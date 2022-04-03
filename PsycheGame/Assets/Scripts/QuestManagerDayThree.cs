using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerDayThree : MonoBehaviour
{
    public Toggle fuel;
    public Toggle batteries;
    public Toggle toolbox;

    public DialogueTrigger npc;

    // Start is called before the first frame update
    void Start()
    {
        if (!QuestTracker.Instance.onDayThree) QuestTracker.Instance.onDayThree = true;
        if (QuestTracker.Instance.canEndDayThree) npc.dialogue.isAvailable = false;
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
        npc.dialogue.isAvailable = false;
    }
}
