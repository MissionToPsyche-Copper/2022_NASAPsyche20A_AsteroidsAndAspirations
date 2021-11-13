using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControlPanel : MonoBehaviour
{

    public Animator ControlPanelAnimator;
    public bool open = true;
    void Update()
    {
        if ( Input.GetKeyDown( "h" ) )
        {
            if (open)
            {
                open = false;
                ControlPanelAnimator.SetTrigger("HideControlPanel");
            }
            else
            {
                open = true;
                ControlPanelAnimator.SetTrigger("OpenControlPanel");
            }
        }
    }
}
