using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wall")
        {
            transform.position = startPos;
        }
    }


}