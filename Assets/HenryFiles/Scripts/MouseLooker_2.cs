using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLooker_2 : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90f;
    public float MaximumX = 90f;
    public bool smooth;
    public float smoothTime = 5f;
    public bool testCursorLock;
    public Slider slider;

    //internal private variables
    private Quaternion m_CharacterTargetRot;
    private Quaternion m_CameraTargetRot;
    private Transform character;
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        // start the game with the cursor locked
        LockCursor(true);

        // get a reference to the character's transform (which this script should be attached to)
        character = gameObject.transform;

        // get a reference to the main camer's transform
        cameraTransform = Camera.main.transform;

        // get the location rotation of the chacter and the camera
        m_CharacterTargetRot = character.localRotation;
        m_CameraTargetRot = cameraTransform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider != null){
            XSensitivity = Mathf.Pow(slider.value,3);
            YSensitivity = Mathf.Pow(slider.value,3);
        }
        // rotate stuff based on the mouse
        if (!MouseLockCursor.paused)
        {
            LookRotation();
            //Debug.Log("Camera Is Rotating");
            // if ESCAPE key is pressed, then unlock the cursor
            if (Input.GetButtonDown("Cancel"))
            {
                testCursorLock = false;
                LockCursor(false);
            } 

            // if the player fires, then relock the cursor
            if (Input.GetButtonDown("Fire1"))
            {
                testCursorLock = true;
                LockCursor(true);
            }
        }
    }
     
    private void LockCursor(bool isLocked)
    {
        if(isLocked)
        {
            testCursorLock = false;

            // make the mouse pointer invisible
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            testCursorLock = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void LookRotation()
    {
        //get the y and x rotation based on the Input manager
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        //calculate the rotation
        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        // clamp the vertical rotation if specified
        if (clampVerticalRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

        //update the character and the camera based on calculations
        if (smooth) //if smooth, then slerp over tim
        {
            character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot, 
                smoothTime * Time.deltaTime);
            cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, m_CameraTargetRot, 
                smoothTime * Time.deltaTime);
        }
        else // not smooth, so just jump
        {
            character.localRotation = m_CharacterTargetRot;
            cameraTransform.localRotation = m_CameraTargetRot;
        }

    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y = q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;

    }
}
