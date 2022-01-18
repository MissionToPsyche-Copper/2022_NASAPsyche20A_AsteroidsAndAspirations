using UnityEngine;

public class MFeedback : MonoBehaviour
{
    public Material _matchMaterial;
    public Material _mismatchMaterial;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeMaterialWithMatch(bool correctMatch)
    {
        if (correctMatch) _renderer.material = _matchMaterial;
        else _renderer.material = _mismatchMaterial;
    }
}