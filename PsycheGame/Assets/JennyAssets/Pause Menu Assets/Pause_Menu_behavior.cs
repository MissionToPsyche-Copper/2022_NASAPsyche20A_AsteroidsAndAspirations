using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu_behavior : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject player;
    private Interactable[] interactables;
    private bool previousPlayerState;

    void Start()
    {
        interactables = FindObjectsOfType<Interactable>();
    }
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
        GetComponent<Animator>().SetTrigger("FadeOut");
        setEnableObjects(true);
        gamePaused = false;
    }
    void Pause()
    {
        previousPlayerState = player.GetComponent<PlayerMovement>().enabled;
        gamePaused = true;
        GetComponent<Animator>().SetTrigger("FadeIn");
        setEnableObjects(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void quitButton()
    {
        Application.Quit();
    }

    private void setEnableObjects( bool paused )
    {
        //player.GetComponent<PlayerMovement>().enabled = paused;
        if ( paused ) player.GetComponent<PlayerMovement>().enabled = previousPlayerState;
        else player.GetComponent<PlayerMovement>().enabled = paused;

        player.GetComponentInChildren<MouseLook>().enabled = paused;
        foreach (Interactable i in interactables)
        {
            i.enabled = paused;
        }
    }
}
