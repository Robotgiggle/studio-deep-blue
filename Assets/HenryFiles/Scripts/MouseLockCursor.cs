using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockCursor : MonoBehaviour
{
    public bool isCursorLock = true;
    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        LockCursor(isCursorLock);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(!paused)
            {
                LockCursor(false);
                Time.timeScale = 0;
                paused = true;
                Debug.Log("Paused");  
            }
        }
        // Should be programmed to work under pressing "resume" within pause menu
        else if (Input.GetButtonDown("Fire1") && paused)
        {
            LockCursor(true);
            Time.timeScale = 1;
            paused = false;
            Debug.Log("Not Paused");
        }
    }

    private void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
