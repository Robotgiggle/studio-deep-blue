using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockCursor : MonoBehaviour
{
    public bool isCursorLock = true;
    public static bool paused = false;
    public bool pauseTest;
    // Start is called before the first frame update
    void Start()
    {
        LockCursor(isCursorLock);
    }

    // Update is called once per frame
    void Update()
    {
        pauseTest = paused;
        if (Input.GetButtonDown("Cancel"))
        { 
            isCursorLock = false;
        }
    }

    public void pause()
    {
        if (!paused)
        {
            LockCursor(false);
            Time.timeScale = 0;
            paused = true;
            Debug.Log("Paused");
        }
    }

    public void Unpause(){
        if (paused)
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
            isCursorLock = true;
            paused = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            isCursorLock = false;
            paused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

}
