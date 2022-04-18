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
    public static bool leftFirstRoom = false;

    void Start()
    {
        leftFirstRoom = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player left first room: " + leftFirstRoom);
        if ( leftFirstRoom )
        {
            if ( !inThisRoom )
            {
                inThisRoom = true;
                Debug.Log("Entered " + roomTitle );
                roomUI.text = roomTitle;
                roomTagAnimator.SetTrigger("ShowRoomTag");
            }
            else
            {
                Debug.Log("Left " + roomTitle);
                inThisRoom = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!leftFirstRoom) leftFirstRoom = true;
    }

}
