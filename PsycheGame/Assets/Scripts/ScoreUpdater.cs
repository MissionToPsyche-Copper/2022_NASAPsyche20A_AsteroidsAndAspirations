using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public int pets = 0;
    public int goodEnd = 0;
    public int badEnd = 0;

    public Text petText;
    public Text goodText;
    public Text badText;

    void Start()
    {
        petText.text = "pets: " + pets;
        goodText.text = "points to good end: " + goodEnd;
        badText.text = "points to bad end: " + badEnd;
    }

    public void AddPets()
    {
        pets++;
        petText.text = "pets: " + pets;
    }

    public void AddGoodEnd()
    {
        goodEnd++;
        goodText.text = "points to good end: " + goodEnd;
    }

       public void AddBadEnd()
    {
        badEnd++;
        badText.text = "points to bad end: " + badEnd;
    }


}
