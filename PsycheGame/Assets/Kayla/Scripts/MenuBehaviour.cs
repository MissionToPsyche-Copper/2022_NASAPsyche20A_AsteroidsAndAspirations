using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public void triggerMenuBehaviour(int i)
    {
        if (i == 0)
        {
            Debug.Log("Start Button is clicked");
            SceneManager.LoadScene("Level"); // Card game level
        }
        if (i == 1)
        {
            Application.Quit(); // CHANGE To LoadScene
            Debug.Log("Quit Button is clicked");

        }
        if (i == 2)
        {
            Debug.Log("Start Button is clicked");
            SceneManager.LoadScene("Guide a spacecraft");

        }
    }
}
