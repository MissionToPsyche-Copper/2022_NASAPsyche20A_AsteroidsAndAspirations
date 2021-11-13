using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTrigger : MonoBehaviour
{
    public Animator AlertAnimator;
    public ScoreUpdater scoreUpdater;

    // Update is called once per frame
    public void SetOffAlarm()
    {
        if (scoreUpdater.talkedTo > 3)
        {
            //scoreUpdater.talkedTo = 0;

            Debug.Log("Alarm set off");
            AlertAnimator.SetTrigger("WarningOn");

        }
        
    }
}
