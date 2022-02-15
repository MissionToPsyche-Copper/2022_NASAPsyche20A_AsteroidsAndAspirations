using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public Text gameOverText;
    public GameObject ship;

    public Text youWinText;
    public int itemsRemaining;
    public Text itemsLeft;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }
    void setVisibleFalse() {
        ship.SetActive(false); // false to hide, true to show
        Debug.Log("Will hide ship");
    }
    void setVisibleTrue() {
        ship.SetActive(true); // false to hide, true to show

    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Asteroid")
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
            gameOverText.gameObject.SetActive(true);
        }
        if (itemsRemaining == 0)
        {
            youWinText.gameObject.SetActive(true);
        }

    }
    
}
