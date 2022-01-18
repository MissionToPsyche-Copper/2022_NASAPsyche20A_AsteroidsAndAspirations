using UnityEngine;

public class MovablePair : MonoBehaviour
{
    private Camera _mainCamera;
    private float _cameraZ;
    private Vector3 _initialPos;
    //If connected to a wire
    private bool _connected;

    private const string _portTag = "Port";

    //how close they need to get before it connects wires
    private const float _dragResponseThreshold = 1;

    void Start()
    {
        _mainCamera = Camera.main;
        _cameraZ = _mainCamera.WorldToScreenPoint(transform.position).z;
    }

    void OnMouseDrag()
    {
        //find position of screen
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraZ);
        Vector3 NewWorldPosition = _mainCamera.ScreenToWorldPoint(ScreenPosition);


        //see if the object is connected
        if (!_connected) { transform.position = NewWorldPosition; }
        else if (Vector3.Distance(a: transform.position, b: NewWorldPosition) > _dragResponseThreshold) { _connected = false; }
    }

    private void OnMouseUp()
    {
        if (!_connected) ResetPosition();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetInitialPosition(Vector3 NewPosition)
    {
        _initialPos = NewPosition;
        transform.position = _initialPos;
    }

    private void ResetPosition()
    {
        transform.position = _initialPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_portTag))
        {
            _connected = true;
            transform.position = other.transform.position;
        }
    }
}