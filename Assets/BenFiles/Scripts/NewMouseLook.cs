using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMouseLook : MonoBehaviour
{   
    // variables 
    public float mouseSensitivity = 100f; 
    public Transform playerBody;
    public float _xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {   
       // this will lock the cursor on the screen
       Cursor.lockState =  CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime is the amount of time that has gone by since the last Update function was called
        // framerate independent
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        // constrain rotation / don't over rotate and look behind player
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
