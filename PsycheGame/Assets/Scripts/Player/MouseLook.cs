using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // controls mouse sensitivity
    public float sensitivity = 1f;

    public Transform playerBody;

    //degree that the camera is rotated along the x-axis
    private float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // get mouse input from user
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // prevent the camera from being able to look 360 degrees up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp( xRotation, -90f, 90f );

        // look side to side
        //rotate the player's body along the y-axis using X-input
        playerBody.Rotate(Vector3.up * mouseX);

        // look up and down
        // instead of rotating the whole body along the x-axis, only the camera itself is being rotated
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
