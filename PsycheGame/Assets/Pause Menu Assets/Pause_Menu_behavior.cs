using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu_behavior : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("");
    }
    public void howToPlay()
    {
        //SceneManager.LoadScene("");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
