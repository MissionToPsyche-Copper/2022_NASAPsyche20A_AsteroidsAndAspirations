using UnityEngine;

public class MatchEntity : MonoBehaviour
{
    public MatchFeedback _feedback;
    public MovablePair _movablePair;
    public Renderer _fixedPairRenderer;
    public MatchManager _matchManager;

    private bool _matched;

    //get the position of the movable object
    public Vector3 GetMovablePairPosition()
    {
        return _movablePair.GetPosition();
    }

    //sets the initial position of the movable object 
    public void SetMovablePairPosition(Vector3 NewMovablePairPosition)
    {
        _movablePair.SetInitialPosition(NewMovablePairPosition);
    }


    //sets what material each pair is going to be 
    public void SetMaterialToPairs(Material PairMaterial)
    {
        _movablePair.GetComponent<Renderer>().material = PairMaterial;
        _fixedPairRenderer.material = PairMaterial;
    }

    //What happens when the object is moved 
    //IsEnter represents if it has actually entered into the area that interacts with the set object
    public void PairObjectInteraction(bool IsEnter, MovablePair movable)
    {

        //If it has entered into the area and matched is currently false for the area
        if (IsEnter && !_matched)
        {
            //if the moved one is part of the correct pair, it sets matched to true
            _matched = (movable == _movablePair);
            if (_matched)
            {
                _matchManager.MatchCount(_matched);
                _feedback.ChangeMaterialWithMatch(_matched);
            }
        }
        //if there is a match and the object leaves the area
        else if (!IsEnter && _matched)
        {
            //if the match is broken 
            _matched = !(movable == _movablePair);
            if (!_matched)
            {
                _matchManager.MatchCount(_matched);
                _feedback.ChangeMaterialWithMatch(_matched);
            }
        }
    }

}