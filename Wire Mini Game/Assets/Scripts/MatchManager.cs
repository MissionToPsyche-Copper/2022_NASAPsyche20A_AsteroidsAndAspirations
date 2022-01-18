using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    public List<Material> _colorMaterials;
    private List<MatchEntity> _matchEntities;
    private int _totalMatchCount;
    private int _currentMatchCount = 0;

    //See how many there are to match, set the colors, and randomize where they start
    void Start()
    {
        _matchEntities = transform.GetComponentsInChildren<MatchEntity>().ToList();
        _totalMatchCount = _matchEntities.Count;
        SetEntityColors();
        RandomizePairPlacements();
    }

    //Shuffles the colors of the objects to be matched
    void SetEntityColors()
    {
        Shuffle(_colorMaterials);

        for (int i = 0; i < _matchEntities.Count; i++)
        {
            _matchEntities[i].SetMaterialToPairs(_colorMaterials[i]);
        }
    }

    void RandomizePairPlacements()
    {
        //vector 3 is x,y,z
        List<Vector3> movablePairPositions = new List<Vector3>();

        //goes through each object that is movable and gets the initial position
        for (int i = 0; i < _matchEntities.Count; i++)
        {
            movablePairPositions.Add(item: _matchEntities[i].GetMovablePairPosition());
        }

        //getting the next match position for them 
        Shuffle(movablePairPositions);

        for (int i = 0; i < _matchEntities.Count; i++)
        {
            _matchEntities[i].SetMovablePairPosition(movablePairPositions[i]);
        }
    }

    //checks if the game is over
    public void MatchCount(bool MatchConnected)
    {
        if (MatchConnected) { _currentMatchCount++; }
        else { _currentMatchCount--; }

        Debug.Log(message: "There are still " + _currentMatchCount + " matches remaining");

        if (_currentMatchCount == _totalMatchCount) { Debug.Log(message: "CONGRATS! All pairs matched"); }
    }


    //setting random colors
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
