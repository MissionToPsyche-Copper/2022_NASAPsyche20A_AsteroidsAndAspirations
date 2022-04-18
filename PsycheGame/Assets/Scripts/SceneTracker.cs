using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public static SceneTracker Instance;

    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //*** DEBUG COMMAND DELETE LATER ***//
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("SKIPPED TO DAY TWO");
            LoadLevel("DayTwo");
        }
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("SKIPPED TO DAY THREE");
            LoadLevel("DayThree");
        }
    }

    public void LoadLevel( string levelName )
    {
        StartCoroutine( LoadingNextScene( levelName ) );
    }

    IEnumerator LoadingNextScene( string levelName )
    {
        //play animation
        transition.SetTrigger("StartFade");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene( levelName );
    }
}
