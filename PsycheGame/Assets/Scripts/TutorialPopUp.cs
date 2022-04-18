using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopUp : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<Pause_Menu_behavior>().Tutorial();
    }

    public void Resume()
    {

        FindObjectOfType<Pause_Menu_behavior>().Resume();
        Destroy(gameObject);
    }
}
