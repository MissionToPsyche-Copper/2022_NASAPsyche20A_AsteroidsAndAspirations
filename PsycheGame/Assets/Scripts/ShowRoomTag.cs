using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRoomTag : MonoBehaviour
{
    public Animator roomTagAnimator;
    public Text roomUI;
    public string roomTitle;
    public bool inThisRoom = false;

    private void OnTriggerEnter(Collider other)
    {
        if ( inThisRoom )
        {
            Debug.Log("Left " + roomTitle);
            inThisRoom = false;
        }
        else
        {
            inThisRoom = true;
            Debug.Log("Entered " + roomTitle );
            roomUI.text = roomTitle;
            roomTagAnimator.SetTrigger("ShowRoomTag");
        }
    }
}
