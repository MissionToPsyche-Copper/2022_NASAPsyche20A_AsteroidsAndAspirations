using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListAnimation : MonoBehaviour
{
    public Animator QuestListAnimator;
    public bool open = true;
    void Update()
    {
        if ( Input.GetKeyDown( "q" ) )
        {
            if (open)
            {
                open = false;
                QuestListAnimator.SetTrigger("CloseQuestList");
            }
            else
            {
                open = true;
                QuestListAnimator.SetTrigger("OpenQuestList");
            }
        }
    }
}
