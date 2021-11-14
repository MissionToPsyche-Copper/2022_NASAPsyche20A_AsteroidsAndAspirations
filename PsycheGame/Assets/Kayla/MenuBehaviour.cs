using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public void triggerMenuBehaviour(int i)
    {
        if(i == 0) { 
                Debug.Log("Start Button is clicked");
                SceneManager.LoadScene("Level");
        }
        if(i == 1) { 
                Application.Quit();
            Debug.Log("Quit Button is clicked");

        }
    }
}
