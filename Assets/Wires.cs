using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    Vector3 startPoint;
    public SpriteRenderer wireEnd;
    Vector3 startPosition;
    public GameObject lightOn;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        //startPoint.x -= 1;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);

                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    //see if all matched
                    Main.Instance.match(1);

                    collider.GetComponent<Wires>()?.Done();
                    Done();
                }
                
                return;
            }
        }

        UpdateWire(newPosition);
    }

    void Done()
    {
        lightOn.SetActive(true);

        Destroy(this);
    }

    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        //update wire to move here
        transform.position = newPosition;
        
        //direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * (transform.lossyScale.x);

        //update size
        float dist = Vector2.Distance((startPoint), newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }

}
