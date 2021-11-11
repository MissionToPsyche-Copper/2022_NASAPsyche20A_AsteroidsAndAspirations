using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to the character controller of the player
    public CharacterController controller;

    // movement speed
    public float speed = 12f;

    void Update()
    {
        // Movement Keys: WASD or Arrow keys
        float x = Input.GetAxis("Horizontal");
        float z =  Input.GetAxis("Vertical");

        // direction of movement
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move( move * speed * Time.deltaTime );
    }
}
