using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public GameObject ship;
    public GameObject timer;

    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public int itemsRemaining;
    public Text itemsLeft;

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }
    void setVisibleFalse() {
        ship.SetActive(false); // false to hide, true to show
        //Debug.Log("Will hide ship");
    }
    void setVisibleTrue() {
        ship.SetActive(true); // false to hide, true to show

    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Meteoroid")
        {
            Destroy(obj.gameObject);
            health = health - 20f;
            Invoke("setVisibleFalse", 0.1f);
            Invoke("setVisibleTrue", 0.5f);


        }
        if (obj.gameObject.tag == "PickUp")
        {
            Destroy(obj.gameObject);
            itemsRemaining = itemsRemaining - 1;
            itemsLeft.text = itemsRemaining.ToString();
        }

        if (health == 0)
        {
            Debug.Log("Health is 0");
            GameOverScreen.SetActive(true);
            GameOverScreen.GetComponent<Animator>().SetTrigger("ShowWinScreen");
            Destroy( timer );
            Destroy( gameObject );
        }
        if (itemsRemaining == 0)
        {
            WinScreen.SetActive(true);
            QuestTracker.Instance.hasFuel = true;
            WinScreen.GetComponent<Animator>().SetTrigger("ShowWinScreen");
            Destroy( timer );
            Destroy( gameObject );
        }

    }
    
}
