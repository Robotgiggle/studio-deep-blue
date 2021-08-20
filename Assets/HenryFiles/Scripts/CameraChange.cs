using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject firstCam;
    //public GameObject thirdCam;
    public int camMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Camera"))
        {
            if(camMode == 1)
            {
                camMode = 3;
            }
            else
            {
                camMode = 1;
            }
            StartCoroutine(cameraSwitch());
        }
    }

    IEnumerator cameraSwitch()
    {
        yield return new WaitForSeconds(0.01f);
        if (camMode == 1)
        {
            Debug.Log("C3");
            firstCam.GetComponent<Camera>().targetDisplay = 2;   //thirdCam.GetComponent<Camera>().targetDisplay;
            //thirdCam.GetComponent<Camera>().targetDisplay = firstCam.GetComponent<Camera>().targetDisplay;
            camMode = 3;
        }
        else if(camMode == 3)
        {
            Debug.Log("C1");
            firstCam.GetComponent<Camera>().targetDisplay = 1;   //thirdCam.GetComponent<Camera>().targetDisplay;
            //firstCam.GetComponent<Camera>().targetDisplay = thirdCam.GetComponent<Camera>().targetDisplay;
            //firstCam.GetComponent<Camera>().targetDisplay = thirdCam.GetComponent<Camera>().targetDisplay;
            camMode = 1;
        }
    }
}
