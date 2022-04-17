using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnableMouse();
    }

    public void EnableMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
