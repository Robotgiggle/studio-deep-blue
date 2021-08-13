using UnityEngine;
using System.Collections;

public class MouseLockCursor : MonoBehaviour {

	public bool isCursorLock = true;
    public static bool paused = false;

	// Use this for initialization
	void Start () {
		LockCursor (isCursorLock);

    }

    // Update is called once per frame
    void Update() {
		if(Input.GetButtonDown("Cancel")){

            if (!paused)
            {
                LockCursor(false);
                Time.timeScale = 0;
                paused = true;
                Debug.Log("Paused");

            }
            //else if ((paused) && (Input.GetButtonUp("Fire1")))
            //{

            //}
        }
        else if (Input.GetButtonDown("Fire2") && paused)
        {
            LockCursor(true);
            Time.timeScale = 1;
            paused = false;
            Debug.Log("Not Paused");
        }

        /*	if(Input.GetButtonDown("Fire1") && (!paused)){
                LockCursor (true);
            }*/
    }

	private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
