using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveForward : MonoBehaviour
{
    void Update()
    {
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(transform.forward * Time.deltaTime *10);

        // Move the object upward in world space 1 unit/second.
        //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }
}
